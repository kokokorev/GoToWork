using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.BusinessLogics;
using GoToWorkDatabaseImplement.Implements;
using Unity;

namespace GoToWorkAdminView
{
    public partial class FormAdmin : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IToyLogic logic;
        private readonly BackUpAbstractLogic backUpAbstractLogic;

        public FormAdmin(ToyLogic logic, BackUpAbstractLogic backUpAbstractLogic)
        {
            this.logic = logic;
            this.backUpAbstractLogic = backUpAbstractLogic;
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewToys.DataSource = list;
                    dataGridViewToys.Columns[0].Visible = false;
                    dataGridViewToys.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewToys.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewToys.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке игрушек", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonNewToy_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormNewToy>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonToyParts_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormToyParts>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonPartsMovement_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPartsMovement>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateAdminArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStatistic>();
            form.ShowDialog();
            LoadData();
        }
    }
}