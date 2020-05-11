using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using GoToWorkBusinessLogic.Enums;

namespace GoToWorkBusinessLogic.BindingModels
{
    [DataContract]
    public class RequestBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int? ProviderId { get; set; }
        [DataMember]
        public string ProviderFIO { get; set; }
        [DataMember]
        public string PartType { get; set; }
        [DataMember]
        public string PartColor { get; set; }
        [DataMember]
        public int PartCount { get; set; }
        [DataMember]
        public RequestStatus RequestStatus { get; set; }
        [DataMember]
        public DateTime? DateExecution { get; set; }
    }
}
