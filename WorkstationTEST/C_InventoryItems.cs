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
    
    public partial class C_InventoryItems
    {
        public int TenantId { get; set; }
        public int InventoryType { get; set; }
        public System.Guid InventoryId { get; set; }
        public System.Guid InventoryItemId { get; set; }
        public int ItemNo { get; set; }
        public System.Guid AssetsId { get; set; }
        public string AssetsNo { get; set; }
        public string AssetsName { get; set; }
        public string Specification { get; set; }
        public decimal AccountQty { get; set; }
        public decimal InventoryQty { get; set; }
        public decimal DifferenceQty { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public string ItemRemark { get; set; }
        public int ItemStatus { get; set; }
        public Nullable<System.Guid> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.Guid> StorehouseId { get; set; }
        public string StoreSpaceName { get; set; }
        public Nullable<decimal> Stprice { get; set; }
        public string ABC { get; set; }
        public string prodno { get; set; }
    }
}
