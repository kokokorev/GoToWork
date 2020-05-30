using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.ViewModels;
using GoToWorkRestApi.Models;

namespace GoToWorkProviderView
{
    public partial class FormOrderPart : Form
    {
        public string PartType
        {
            set
            {
                partType = value;
            }
        }

        private string partType;

        public string PartColor
        {
            set
            {
                partColor = value;
            }
        }

        private string partColor;

        public int PartCount
        {
            set
            {
                partCount = value;
                LoadData();
            }
        }

        private int partCount;

        public FormOrderPart()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            textBoxPartType.Text = partType;
            textBoxPartColor.Text = partColor;
            textBoxCount.Text = partCount.ToString();
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPartType.Text))
            {
                MessageBox.Show("Заполните поле Тип детали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPartColor.Text))
            {
                MessageBox.Show("Заполните поле Цвет детали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<PartViewModel> parts = APIClient.GetRequest<List<PartViewModel>>($"api/main/getpartlist");

                bool flag = false;
                foreach (var part in parts.Where(rec => rec.PartType == textBoxPartType.Text && rec.PartColor == textBoxPartColor.Text && rec.PartStatus == PartStatus.Прибыл))
                {
                    APIClient.PostRequest("api/main/orderpart", new PartBindingModel
                    {
                        ProviderId = Program.Provider.Id,
                        ProviderFIO = Program.Provider.FIO,
                        PartType = textBoxPartType.Text,
                        PartColor = textBoxPartColor.Text,
                        PartCount = part.PartCount + Convert.ToInt32(textBoxCount.Text),
                        PartStatus = PartStatus.Прибыл,
                        DateRecieve = DateTime.Now
                    });
                    flag = true;
                }


                if (!flag)
                {
                    APIClient.PostRequest("api/main/orderpart", new PartBindingModel
                    {
                        ProviderId = Program.Provider.Id,
                        ProviderFIO = Program.Provider.FIO,
                        PartType = textBoxPartType.Text,
                        PartColor = textBoxPartColor.Text,
                        PartCount = Convert.ToInt32(textBoxCount.Text),
                        PartStatus = PartStatus.Прибыл,
                        DateRecieve = DateTime.Now
                    });
                }

                MessageBox.Show("Заказ создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
