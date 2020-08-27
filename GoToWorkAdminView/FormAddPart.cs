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
using GoToWorkDatabaseImplement.Implements;
using Unity;

namespace GoToWorkAdminView
{
    public partial class FormAddPart : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IPartLogic partlogic;
        public int Id
        {
            get { return Convert.ToInt32(dataGridViewAvailableParts.SelectedRows[0].Cells[0].Value); }
        }
        public string PartType
        {
            get { return dataGridViewAvailableParts.SelectedRows[0].Cells[1].Value.ToString(); }
        }

        public string PartColor
        {
            get
            {
                return dataGridViewAvailableParts.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        public int PartCount
        {
            get
            {
                return Convert.ToInt32(textBoxPartCount.Text);
            }
        }

        public FormAddPart(PartLogic partlogic)
        {
            this.partlogic = partlogic;
            InitializeComponent();
        }

        private void FormAddPart_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = partlogic.Read(new PartBindingModel { PartStatus = PartStatus.Прибыл });

                dataGridViewAvailableParts.Rows.Clear();
                foreach (var elem in list)
                {
                    if (elem.PartCount > 0)
                    {
                        dataGridViewAvailableParts.Rows.Add(new object[]
                        {
                            elem.Id,
                            elem.PartType,
                            elem.PartColor,
                            elem.PartCount
                        });
                    }
                }
                /*if (list != null)
                {
                    dataGridViewAvailableParts.DataSource = list;
                    dataGridViewAvailableParts.Columns[0].Visible = false;
                    dataGridViewAvailableParts.Columns[1].Visible = false;
                    dataGridViewAvailableParts.Columns[2].Visible = false;
                    dataGridViewAvailableParts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewAvailableParts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewAvailableParts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewAvailableParts.Columns[6].Visible = false;
                    dataGridViewAvailableParts.Columns[7].Visible = false;
                    dataGridViewAvailableParts.Columns[8].Visible = false;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке деталей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPartCount.Text))
            {
                MessageBox.Show("Добавьте количество деталей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridViewAvailableParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите деталь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(textBoxPartCount.Text) > Convert.ToInt32(dataGridViewAvailableParts.SelectedRows[0].Cells[3].Value))
            {
                MessageBox.Show("Не хватает деталей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonRequestPart_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequestPart>();
            form.ShowDialog();
            LoadData();
        }
    }
}
