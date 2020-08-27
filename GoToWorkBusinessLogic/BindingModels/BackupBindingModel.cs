using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
<<<<<<< HEAD
using GoToWorkBusinessLogic.Enums;
=======
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152

namespace GoToWorkBusinessLogic.BindingModels
{
    [DataContract]
    public class BackupBindingModel
    {
        [DataMember]
        public string SelectedPath { get; set; }
    }
}
