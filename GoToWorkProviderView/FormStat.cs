using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkProviderView
{
    public partial class FormStat : Form
    {
        public FormStat()
        {
            InitializeComponent();
        }

        private void buttonMakeStat_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {

                List<PartViewModel> parts = APIClient.GetRequest<List<PartViewModel>>($"api/main/getpartlist");
                List<string> partsType = new List<string>() { };

                int sum = 0;
                if (parts != null)
                {
                    foreach (var part in parts.Where(rec =>
                        (rec.DateRecieve.Date >= dateTimePickerFrom.Value.Date &&
                         rec.DateRecieve.Date <= dateTimePickerTo.Value.Date)))
                    {
                        sum += part.PartCount;
                    }

                    dataGridViewParts.Rows.Clear();
                    foreach (var part in parts.Where(rec => (rec.DateRecieve.Date >= dateTimePickerFrom.Value.Date && rec.DateRecieve.Date <= dateTimePickerTo.Value.Date) && rec.DateTransfer == null))
                    {
                        if (!partsType.Contains(part.PartType))
                        {
                            int count = part.PartCount;
                            foreach (var partTransfer in parts.Where(recT =>
                                recT.PartType == part.PartType && recT.DateTransfer != null &&
                                recT.DateTransfer.Value.Date >= dateTimePickerFrom.Value.Date &&
                                recT.DateTransfer.Value.Date <= dateTimePickerTo.Value.Date))
                            {

                                count += partTransfer.PartCount;
                            }

                            double tmp = ((double)count / sum);
                            dataGridViewParts.Rows.Add(new object[]
                            {
                                part.PartType,
                                ((double)((double)count / sum) * 100).ToString() + "%"
                            });
                            partsType.Add(part.PartType);
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
