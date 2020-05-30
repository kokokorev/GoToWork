using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.BusinessLogics;
using GoToWorkBusinessLogic.Enums;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkProviderView
{
    public partial class FormRequests : Form
    {
        public FormRequests()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewRequests.DataSource = APIClient.GetRequest<List<RequestViewModel>>($"api/main/getrequestlist");

                dataGridViewRequests.Columns[0].Visible = false;
                dataGridViewRequests.Columns[1].Visible = false;
                dataGridViewRequests.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewRequests.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewRequests.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewRequests.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewRequests.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewRequests.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                comboBoxForm.DisplayMember = "Document";
                comboBoxForm.ValueMember = "Format";
                comboBoxForm.DataSource = new List<string>() { ".docx", ".xlsx" };
                comboBoxForm.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrderPart_Click(object sender, EventArgs e)
        {
            if (comboBoxForm.SelectedValue == null)
            {
                MessageBox.Show("Выберите формат документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new FormOrderPart();

            if (dataGridViewRequests.SelectedRows != null)
            {
                form.PartType = dataGridViewRequests.SelectedRows[0].Cells[3].Value.ToString();
                form.PartColor = dataGridViewRequests.SelectedRows[0].Cells[4].Value.ToString();
                form.PartCount = (int)dataGridViewRequests.SelectedRows[0].Cells[5].Value;
            }

            DateTime nowTime = DateTime.Now;
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APIClient.PostRequest("api/main/changerequeststatus", new RequestBindingModel
                    {
                        Id = (int)dataGridViewRequests.SelectedRows[0].Cells[0].Value,
                        ProviderId = Program.Provider.Id,
                        ProviderFIO = Program.Provider.FIO,
                        PartType = dataGridViewRequests.SelectedRows[0].Cells[3].Value.ToString(),
                        PartColor = dataGridViewRequests.SelectedRows[0].Cells[4].Value.ToString(),
                        PartCount = (int)dataGridViewRequests.SelectedRows[0].Cells[5].Value,
                        RequestStatus = RequestStatus.Выполненный,
                        DateExecution = nowTime
                    });

                    if (comboBoxForm.SelectedValue == ".docx")
                    {
                        using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                APIClient.PostRequest("api/main/createwordreport", new ReportBindingModel
                                {
                                    Email = Program.Provider.Email,
                                    FileName = dialog.FileName.ToString(),
                                    Date = nowTime,
                                    PartType = dataGridViewRequests.SelectedRows[0].Cells[3].Value.ToString(),
                                    PartColor = dataGridViewRequests.SelectedRows[0].Cells[4].Value.ToString(),
                                    PartCount = (int)dataGridViewRequests.SelectedRows[0].Cells[5].Value
                                });

                                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBoxForm.SelectedValue == ".xlsx")
                    {
                        using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                APIClient.PostRequest("api/main/createexcelreport", new ReportBindingModel
                                {
                                    Email = Program.Provider.Email,
                                    FileName = dialog.FileName.ToString(),
                                    Date = nowTime,
                                    PartType = dataGridViewRequests.SelectedRows[0].Cells[3].Value.ToString(),
                                    PartColor = dataGridViewRequests.SelectedRows[0].Cells[4].Value.ToString(),
                                    PartCount = (int)dataGridViewRequests.SelectedRows[0].Cells[5].Value
                                });

                                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadData();
        }
    }
}
