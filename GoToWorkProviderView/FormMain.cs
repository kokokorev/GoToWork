using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkProviderView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewParts.DataSource = APIClient.GetRequest<List<PartViewModel>>($"api/main/getpartlist");

                dataGridViewParts.Columns[0].Visible = false;
                dataGridViewParts.Columns[1].Visible = false;
                dataGridViewParts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewParts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewParts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewParts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewParts.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewParts.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewParts.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrderPart_Click(object sender, EventArgs e)
        {
            var form = new FormOrderPart();
            form.ShowDialog();
            LoadData();
        }

        private void buttonRequests_Click(object sender, EventArgs e)
        {
            var form = new FormRequests();
            form.ShowDialog();
            LoadData();
        }

        private void buttonPartsMovement_Click(object sender, EventArgs e)
        {
            var form = new FormPartsMovement();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            var form = new FormStat();
            form.ShowDialog();
            LoadData();
        }
    }
}