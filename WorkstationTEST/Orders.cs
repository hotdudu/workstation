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
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.OrderItems = new HashSet<OrderItems>();
            this.ReceivePayment1 = new HashSet<ReceivePayment>();
            this.Requisitions = new HashSet<Requisitions>();
        }
    
        public int TenantId { get; set; }
        public System.Guid OrderId { get; set; }
        public int OrderType { get; set; }
        public string OrderNo { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.Guid PartnerId { get; set; }
        public Nullable<System.DateTime> PrepaidDate { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public int TaxNo { get; set; }
        public decimal TaxRate { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.Guid> SalesmanId { get; set; }
        public string CurrencyNo { get; set; }
        public decimal CurrencyExchangeRate { get; set; }
        public decimal Discounts { get; set; }
        public decimal ReDiscounts { get; set; }
        public decimal DiscountMoney { get; set; }
        public string ProductNote { get; set; }
        public string Terms { get; set; }
        public string Contact { get; set; }
        public string Consignee { get; set; }
        public Nullable<System.Guid> DeliveryAddressId { get; set; }
        public Nullable<System.Guid> Deposits { get; set; }
        public string OrderRemark { get; set; }
        public int OrderStatus { get; set; }
        public string CustOrderNo { get; set; }
        public System.Guid CreateUserId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.Guid> UpdateUserId { get; set; }
        public int OrderYM { get; set; }
        public int BelongYM { get; set; }
        public Nullable<bool> Urgent { get; set; }
        public int PutUp { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Currency Currency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual Users Users { get; set; }
        public virtual Partners Partners { get; set; }
        public virtual ReceivePayment ReceivePayment { get; set; }
        public virtual Salesman Salesman { get; set; }
        public virtual TaxType TaxType { get; set; }
        public virtual Users Users1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceivePayment> ReceivePayment1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requisitions> Requisitions { get; set; }
    }
}
