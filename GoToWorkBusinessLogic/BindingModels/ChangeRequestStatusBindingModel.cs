using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace GoToWorkBusinessLogic.BindingModels
{
    [DataContract]
    public class ChangeRequestStatusBindingModel
    {
        [DataMember]
        public int RequestId { get; set; }
        [DataMember]
        public int ProviderId { get; set; }
    }
}
