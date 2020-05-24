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
    public partial class FormToyParts : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IToyLogic toyLogic;
        private readonly ReportLogic reportLogic;

        public FormToyParts(IToyLogic toyLogic, ReportLogic reportLogic)
        {
            this.toyLogic = toyLogic;
            this.reportLogic = reportLogic;
            InitializeComponent();
        }

        private void FormToyParts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = toyLogic.Read(null);
                if (list != null)
                {
                    dataGridViewPickToy.DataSource = list;
                    dataGridViewPickToy.Columns[0].Visible = false;
                    dataGridViewPickToy.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewPickToy.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewPickToy.Columns[3].Visible = false;

                    comboBoxDocForm.DisplayMember = "Document";
                    comboBoxDocForm.ValueMember = "Format";
                    comboBoxDocForm.DataSource = new List<string>() { ".docx", ".xlsx" };
                    comboBoxDocForm.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке игрушек", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (dataGridViewPickToy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите деталь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxDocForm.SelectedValue == null)
            {
                MessageBox.Show("Выберите формат документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните поле Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxDocForm.SelectedValue == ".docx")
            {
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (comboBoxDocForm.SelectedValue == ".xlsx")
            {
                using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        reportLogic.SaveToExcelFile(new ReportBindingModel
                        {
                            Email = textBoxEmail.Text,
                            FileName = dialog.FileName,
                            ToyModel = toyLogic.Read(new ToyBindingModel { Id = (int)dataGridViewPickToy.SelectedRows[0].Cells[0].Value }).FirstOrDefault()
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
