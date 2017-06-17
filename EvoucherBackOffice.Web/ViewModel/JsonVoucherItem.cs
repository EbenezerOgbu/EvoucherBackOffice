using System.Runtime.Serialization;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.ViewModel
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonVoucherItem
    {
        [DataMember]
        public string VoucherCode { get; set; }
        [DataMember]
        public int Qty { get; set; }
    }
}