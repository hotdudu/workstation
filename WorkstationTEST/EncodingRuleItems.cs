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
    
    public partial class EncodingRuleItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EncodingRuleItems()
        {
            this.EncodingItemValues = new HashSet<EncodingItemValues>();
            this.EncodingItemValues1 = new HashSet<EncodingItemValues>();
            this.EncodingRuleItems1 = new HashSet<EncodingRuleItems>();
        }
    
        public int TenantId { get; set; }
        public int EncodingClass { get; set; }
        public System.Guid EncodingId { get; set; }
        public System.Guid EncodingItemId { get; set; }
        public int ItemNo { get; set; }
        public string ItemCaption { get; set; }
        public int Required { get; set; }
        public int EncodingLength { get; set; }
        public string FullChar { get; set; }
        public int ItemStatus { get; set; }
        public Nullable<System.Guid> ParentRuleId { get; set; }
        public int MaxLength { get; set; }
        public int InputType { get; set; }
        public int ShareOpen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncodingItemValues> EncodingItemValues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncodingItemValues> EncodingItemValues1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncodingRuleItems> EncodingRuleItems1 { get; set; }
        public virtual EncodingRuleItems EncodingRuleItems2 { get; set; }
        public virtual EncodingRules EncodingRules { get; set; }
    }
}
