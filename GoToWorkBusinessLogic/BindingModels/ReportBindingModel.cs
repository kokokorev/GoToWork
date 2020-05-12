using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string Email { get; set; }
        public string FileName { get; set; }
        public ToyViewModel ToyModel { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateTo { get; set; }
        public string PartType { get; set; }
        public string PartColor { get; set; }
        public int PartCount { get; set; }
        public List<ToyViewModel> ToyDict { get; set; }
        public List<PartViewModel> PartDict { get; set; }
        public List<DateTime> dates { get; set; }
    }
}
