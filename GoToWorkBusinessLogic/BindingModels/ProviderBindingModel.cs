﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace GoToWorkBusinessLogic.BindingModels
{
    [DataContract]
    public class ProviderBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
