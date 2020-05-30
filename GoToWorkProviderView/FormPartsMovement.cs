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
    public partial class FormPartsMovement : Form
    {
        public FormPartsMovement()
        {
            InitializeComponent();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                List<PartViewModel> parts = APIClient.GetRequest<List<PartViewModel>>($"api/main/getpartlist");
                List<string> partsType = new List<string>() { };

                if (parts != null)
                {
                    decimal count = 0;
                    dataGridViewParts.Rows.Clear();
                    foreach (var part in parts.Where(rec => (rec.DateRecieve.Date >= dateTimePickerFrom.Value.Date && rec.DateRecieve.Date <= dateTimePickerTo.Value.Date) && rec.DateTransfer == null))
                    {
                        if (!partsType.Contains(part.PartType))
                        {
                            decimal countRecieve = 0;
                            foreach (var partTransfer in parts.Where(recT =>
                                recT.PartType == part.PartType && recT.DateTransfer != null &&
                                recT.DateTransfer.Value.Date >= dateTimePickerFrom.Value.Date &&
                                recT.DateTransfer.Value.Date <= dateTimePickerTo.Value.Date))
                            {
                                dataGridViewParts.Rows.Add(new object[]
                                {
                                    partTransfer.DateTransfer.Value.Date.ToShortDateString(),
                                    partTransfer.PartType,
                                    partTransfer.PartColor,
                                    partTransfer.PartCount.ToString(),
                                    partTransfer.PartStatus.ToString()
                                });
                                countRecieve += partTransfer.PartCount;
                            }

                            dataGridViewParts.Rows.Add(new object[]
                            {
                                part.DateRecieve.Date.ToShortDateString(),
                                part.PartType,
                                part.PartColor,
                                (part.PartCount + countRecieve).ToString(),
                                part.PartStatus.ToString()
                            });
                            count += part.PartCount + countRecieve;
                            dataGridViewParts.Rows.Add(new object[] { });

                            partsType.Add(part.PartType);
                        }
                    }
                    dataGridViewParts.Rows.Add(new object[] { "", "", "", "Всего прибыло:", count.ToString() });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            APIClient.PostRequest("api/main/createpdfreport", new ReportBindingModel
                            {
                                Email = Program.Provider.Email,
                                FileName = dialog.FileName,
                                Date = dateTimePickerFrom.Value.Date,
                                DateTo = dateTimePickerTo.Value.Date
                            });

                            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
