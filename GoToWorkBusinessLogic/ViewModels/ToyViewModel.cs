using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GoToWorkBusinessLogic.ViewModels
{
    public class ToyViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название игрушки")] public string ToyName { get; set; }
        [DisplayName("Дата создания")] public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, string, int)> ToyParts { get; set; }
    }
}
