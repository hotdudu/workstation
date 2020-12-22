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
    
    public partial class ProductStore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductStore()
        {
            this.ProductStoreItem = new HashSet<ProductStoreItem>();
        }
    
        public System.Guid ProductStoreId { get; set; }
        public int TenantId { get; set; }
        public System.Guid AssetsId { get; set; }
        public decimal OrderQty { get; set; }
        public decimal PurchaseQty { get; set; }
        public decimal StoreQty { get; set; }
        public decimal MakeQty { get; set; }
        public decimal RealQty { get; set; }
        public decimal StoreMoney { get; set; }
        public string CurrencyNo { get; set; }
        public Nullable<System.DateTime> LastSalesDate { get; set; }
        public Nullable<System.DateTime> LastGetDate { get; set; }
    
        public virtual Assets Assets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductStoreItem> ProductStoreItem { get; set; }
    }
}
