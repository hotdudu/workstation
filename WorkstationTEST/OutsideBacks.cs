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
    
    public partial class OutsideBacks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OutsideBacks()
        {
            this.OutsideBackItems = new HashSet<OutsideBackItems>();
        }
    
        public int TenantId { get; set; }
        public System.Guid OutsideBackId { get; set; }
        public string OutsideBackNo { get; set; }
        public int VoucherType { get; set; }
        public System.DateTime OutsideBackDate { get; set; }
        public System.Guid PartnerId { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public int TaxNo { get; set; }
        public decimal TaxRate { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string CurrencyNo { get; set; }
        public decimal CurrencyExchangeRate { get; set; }
        public decimal Discounts { get; set; }
        public decimal DiscountMoney { get; set; }
        public string Terms { get; set; }
        public Nullable<System.Guid> Deposits { get; set; }
        public string OutsideBackRemark { get; set; }
        public int OutsideBackStatus { get; set; }
        public System.Guid CreateUserId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.Guid> UpdateUserId { get; set; }
        public int OutsideBackYM { get; set; }
        public int BelongYM { get; set; }
        public string Invoice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutsideBackItems> OutsideBackItems { get; set; }
    }
}
