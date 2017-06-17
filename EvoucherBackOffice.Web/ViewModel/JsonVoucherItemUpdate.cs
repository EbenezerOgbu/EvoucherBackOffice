using System.Runtime.Serialization;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.ViewModel
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonVoucherItemUpdate
    {
        [DataMember]
        public JsonVoucherItem[] Items { get; set; }
    }
}