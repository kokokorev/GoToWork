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
using Unity;

namespace GoToWorkAdminView
{
    public partial class FormStatistic : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        private readonly IToyLogic logic;

        public FormStatistic(IToyLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void FormStatistic_Load(object sender, EventArgs e)
        {
            var list = logic.Read(null);

            foreach (var toy in list)
            {
                int countPart = 0;
                var parts = toy.ToyParts.Values;
                foreach (var part in parts)
                {
                    countPart += part.Item3;
                }

                this.chart1.Series["Количество деталей"].Points.AddXY(toy.ToyName, countPart);
            }
        }
    }
}
