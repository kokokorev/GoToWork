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
    public partial class FormPartsMovement : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IToyLogic toyLogic;
        private readonly ReportLogic reportLogic;
        private Dictionary<int, (string, string, int)> toyParts;

        public FormPartsMovement(IToyLogic toyLogic, ReportLogic reportLogic)
        {
            this.toyLogic = toyLogic;
            this.reportLogic = reportLogic;
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
                var dict = toyLogic.Read(null);
                List<DateTime> dates = new List<DateTime>();
                foreach (var toy in dict)
                {
                    if (toy.DateCreate >= dateTimePickerFrom.Value.Date &&
                        toy.DateCreate <= dateTimePickerTo.Value.Date)
                    {
                        bool flag = false;
                        foreach (var date in dates)
                        {
                            if (date.Date == toy.DateCreate.Date)
                            {
                                flag = true;
                            }
                        }

                        if (!flag)
                        {
                            dates.Add(toy.DateCreate);
                        }
                    }
                }

                decimal countParts = 0;
                if (dict != null)
                {
                    dataGridViewParts.Rows.Clear();

                    foreach (var date in dates)
                    {
                        bool dateFlag = false;

                        foreach (var toy in dict.Where(rec => rec.DateCreate.Date == date.Date))
                        {
                            toyParts = toy.ToyParts;

                            foreach (var tp in toyParts)
                            {
                                if (!dateFlag)
                                {
                                    dataGridViewParts.Rows.Add(new object[]
                                    {
                                        date.ToShortDateString(),
                                        tp.Value.Item1,
                                        tp.Value.Item2,
                                        tp.Value.Item3,
                                        toy.ToyName
                                    });
                                    dateFlag = true;
                                    countParts++;
                                }
                                else if (dateFlag)
                                {
                                    dataGridViewParts.Rows.Add(new object[]
                                    {

                                        "",
                                        tp.Value.Item1,
                                        tp.Value.Item2,
                                        tp.Value.Item3,
                                        toy.ToyName
                                    });
                                    countParts++;
                                }
                            }
                            dataGridViewParts.Rows.Add(new object[] { });
                        }
                    }
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

            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните поле Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var dict = toyLogic.Read(null);
                List<DateTime> dates = new List<DateTime>();
                foreach (var toy in dict)
                {
                    if (toy.DateCreate >= dateTimePickerFrom.Value.Date &&
                        toy.DateCreate <= dateTimePickerTo.Value.Date)
                    {
                        bool flag = false;
                        foreach (var date in dates)
                        {
                            if (date.Date == toy.DateCreate.Date)
                            {
                                flag = true;
                            }
                        }

                        if (!flag)
                        {
                            dates.Add(toy.DateCreate);
                        }
                    }
                }

                using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            reportLogic.SaveToPdfFile(new ReportBindingModel
                            {
                                Email = textBoxEmail.Text,
                                FileName = dialog.FileName,
                                Date = dateTimePickerFrom.Value.Date,
                                DateTo = dateTimePickerTo.Value.Date,
                                ToyDict = dict,
                                dates = dates
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