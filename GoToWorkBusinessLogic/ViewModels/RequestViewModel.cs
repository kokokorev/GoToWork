using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GoToWorkBusinessLogic.Enums;
using System.Runtime.Serialization;

namespace GoToWorkBusinessLogic.ViewModels
{
    [DataContract]
    public class RequestViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? ProviderId { get; set; }
        [DataMember]
        [DisplayName("Поставщик")] public string ProviderFIO { get; set; }
        [DataMember]
        [DisplayName("Тип детали")] public string PartType { get; set; }
        [DataMember]
        [DisplayName("Цвет детали")] public string PartColor { get; set; }
        [DataMember]
        [DisplayName("Количество")] public int PartCount { get; set; }
        [DataMember]
        [DisplayName("Статус заказа")] public RequestStatus RequestStatus { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")] public DateTime? DateExecution { get; set; }
    }
}
