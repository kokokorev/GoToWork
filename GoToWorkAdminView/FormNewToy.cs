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
using GoToWorkBusinessLogic.BusinessLogics;
using GoToWorkBusinessLogic.Interfaces;
using Unity;

namespace GoToWorkAdminView
{
    public partial class FormNewToy : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IToyLogic toyLogic;
        private readonly IPartLogic partLogic;
        private readonly PartStatusLogic partStatuslogic;

        private Dictionary<int, (string, string, int)> toyParts;

        public FormNewToy(IToyLogic toyLogic, IPartLogic partLogic, PartStatusLogic partStatuslogic)
        {
            this.toyLogic = toyLogic;
            this.partLogic = partLogic;
            this.partStatuslogic = partStatuslogic;
            InitializeComponent();
        }

        private void FormNewToy_Load(object sender, EventArgs e)
        {
            dataGridViewPartsList.Columns.Add("Id", "Id");
            dataGridViewPartsList.Columns.Add("PartType", "Тип детали");
            dataGridViewPartsList.Columns.Add("PartColor", "Цвет ");
            dataGridViewPartsList.Columns.Add("PartCount", "Количество");
            dataGridViewPartsList.Columns[0].Visible = false;
            dataGridViewPartsList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPartsList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPartsList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPartsList.AllowUserToAddRows = false;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (toyParts != null)
                {
                    dataGridViewPartsList.Rows.Clear();
                    foreach (var tp in toyParts)
                    {
                        dataGridViewPartsList.Rows.Add(new object[]
                        {
                            tp.Key,
                            tp.Value.Item1,
                            tp.Value.Item2,
                            tp.Value.Item3
                        });
                    }
                }
                else
                {
                    toyParts = new Dictionary<int, (string, string, int)>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddPart>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                toyParts.Add(form.Id, (form.PartType, form.PartColor, form.PartCount));

                LoadData();
            }
            LoadData();
        }

        private void buttonRequestPart_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequestPart>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxToyName.Text))
            {
                MessageBox.Show("Добавьте название игрушки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridViewPartsList.RowCount == 0)
            {
                MessageBox.Show("Добавьте деталей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (var tp in toyParts)
                {
                    partStatuslogic.ChangePartStatus(new ChangePartStatusBindingModel
                    {
                        PartId = tp.Key,
                        PartCount = tp.Value.Item3
                    });
                }

                toyLogic.CreateOrUpdate(new ToyBindingModel
                {
                    ToyName = textBoxToyName.Text,
                    DateCreate = DateTime.Now,
                    ToyParts = toyParts
                });
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
