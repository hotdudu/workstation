//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkstationTEST
{
    using System;
    using System.Collections.Generic;
    
    public partial class EncodingItemValues
    {
        public System.Guid EncodingItemId { get; set; }
        public System.Guid EncodingValueId { get; set; }
        public int ItemNo { get; set; }
        public string EncodingValue { get; set; }
        public string ValueCaption { get; set; }
        public Nullable<System.Guid> SubRuleId { get; set; }
        public Nullable<System.Guid> ImageId { get; set; }
        public int ShareOpen { get; set; }
    
        public virtual EncodingRuleItems EncodingRuleItems { get; set; }
        public virtual EncodingRuleItems EncodingRuleItems1 { get; set; }
        public virtual ImageStores ImageStores { get; set; }
    }
}
