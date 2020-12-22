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
    
    public partial class Evaluate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evaluate()
        {
            this.OrderItems = new HashSet<OrderItems>();
            this.QuotationItems = new HashSet<QuotationItems>();
        }
    
        public Nullable<int> TenantId { get; set; }
        public System.Guid EvaluateId { get; set; }
        public int EvaluateType { get; set; }
        public string AssetsNo { get; set; }
        public string AssetsName { get; set; }
        public string Specification { get; set; }
        public string Accuracy { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public int StandardNo { get; set; }
        public bool Addition { get; set; }
        public string Od { get; set; }
        public decimal OdMm { get; set; }
        public decimal Pitch { get; set; }
        public decimal PitchMm { get; set; }
        public string TapShapeNo { get; set; }
        public decimal TapFullLength { get; set; }
        public decimal TapScrewLength { get; set; }
        public string TapFood { get; set; }
        public decimal TapHandleOd { get; set; }
        public string TapHandleShape { get; set; }
        public int TapEdgeQty { get; set; }
        public string TapCutAccuracy { get; set; }
        public decimal AdjustCost { get; set; }
        public bool SpecialAccuracy { get; set; }
        public bool LeftScrew { get; set; }
        public decimal ScrewQty { get; set; }
        public bool TapSpecialHandleOd { get; set; }
        public bool TapSpecialPitch { get; set; }
        public int TapBasLenght { get; set; }
        public bool SpecialHillShape { get; set; }
        public bool SurfaceType { get; set; }
        public decimal LengthRatio { get; set; }
        public decimal ListPrice { get; set; }
        public System.Guid UpdateUserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public System.Guid StandardId { get; set; }
        public string CalculateList { get; set; }
        public bool MicroPitch { get; set; }
        public string EvaluateFigureNo { get; set; }
        public Nullable<decimal> GoOdBas { get; set; }
        public Nullable<decimal> GoOdUpTolerance { get; set; }
        public Nullable<decimal> GoOdDownTolerance { get; set; }
        public Nullable<decimal> GoMinBas { get; set; }
        public Nullable<decimal> GoMinUpTolerance { get; set; }
        public Nullable<decimal> GoMinDownTolerance { get; set; }
        public Nullable<decimal> AngleLength { get; set; }
        public Nullable<decimal> AngleWidth { get; set; }
        public Nullable<decimal> ApexDiameter { get; set; }
        public Nullable<int> SpecialMaterial { get; set; }
    
        public virtual EvaluateFigures EvaluateFigures { get; set; }
        public virtual StandardSet StandardSet { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationItems> QuotationItems { get; set; }
    }
}
