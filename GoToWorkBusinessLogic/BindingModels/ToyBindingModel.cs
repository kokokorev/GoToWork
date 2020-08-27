using System;
using System.Collections.Generic;
using System.Text;

namespace GoToWorkBusinessLogic.BindingModels
{
    public class ToyBindingModel
    {
        public int? Id { get; set; }
        public string ToyName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, string, int)> ToyParts { get; set; }

    }
}
