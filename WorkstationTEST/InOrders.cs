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
    
    public partial class InOrders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InOrders()
        {
            this.InOrderItems = new HashSet<InOrderItems>();
        }
    
        public int TenantId { get; set; }
        public System.Guid InOrderId { get; set; }
        public int InOrderType { get; set; }
        public string InOrderNo { get; set; }
        public System.DateTime InOrderDate { get; set; }
        public System.Guid PartnerId { get; set; }
        public Nullable<System.DateTime> PrepaidDate { get; set; }
        public string InOrderRemark { get; set; }
        public int InOrderStatus { get; set; }
        public System.Guid CreateUserId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.Guid> UpdateUserId { get; set; }
        public int InOrderYM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InOrderItems> InOrderItems { get; set; }
    }
}
