using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using GoToWorkBusinessLogic.Enums;

namespace GoToWorkBusinessLogic.BindingModels
{
    [DataContract]
    public class BackupBindingModel
    {
        [DataMember]
        public string SelectedPath { get; set; }
    }
}
