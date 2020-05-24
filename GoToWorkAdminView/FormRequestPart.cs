using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.Interfaces;
using Unity;

namespace GoToWorkAdminView
{
    public partial class FormRequestPart : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IRequestLogic requestLogic;

        public FormRequestPart(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
            InitializeComponent();
        }

        private void buttonSendRequest_Click(object sender, EventArgs e)
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
                requestLogic.CreateOrUpdate(new RequestBindingModel
                {
                    PartType = textBoxPartType.Text,
                    PartColor = textBoxPartColor.Text,
                    PartCount = Convert.ToInt32(textBoxCount.Text),
                    RequestStatus = RequestStatus.Активный
                });
                MessageBox.Show("Запрос отправлен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
