using System;
using System.Collections.Generic;
using System.Text;

namespace GoToWorkBusinessLogic.BindingModels
{
    public class CreateRequestBindingModel
    {
        public string PartType { get; set; }
        public string PartColor { get; set; }
        public int PartCount { get; set; }
    }
}
