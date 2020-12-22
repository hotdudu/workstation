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
    
    public partial class AccuracyThreadGauge
    {
        public System.Guid StandardId { get; set; }
        public string StandardCategory { get; set; }
        public int StandardNo { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string Specification { get; set; }
        public string Accuracy { get; set; }
        public decimal Pitch { get; set; }
        public decimal PitchMm { get; set; }
        public string Od { get; set; }
        public decimal OdMm { get; set; }
        public Nullable<decimal> GoOdBas { get; set; }
        public Nullable<decimal> GoOdUpTolerance { get; set; }
        public Nullable<decimal> GoOdDownTolerance { get; set; }
        public Nullable<decimal> GoMinBas { get; set; }
        public Nullable<decimal> GoMinUpTolerance { get; set; }
        public Nullable<decimal> GoMinDownTolerance { get; set; }
        public Nullable<int> GoAngleTolerance { get; set; }
        public Nullable<decimal> NgOdBas { get; set; }
        public Nullable<decimal> NgOdUpTolerance { get; set; }
        public Nullable<decimal> NgOdDownTolerance { get; set; }
        public Nullable<decimal> NgMinBas { get; set; }
        public Nullable<decimal> NgMinUpTolerance { get; set; }
        public Nullable<decimal> NgMinDownTolerance { get; set; }
        public Nullable<int> NgAngleTolerance { get; set; }
        public string PitchTolerance { get; set; }
        public Nullable<decimal> OdBasLength { get; set; }
        public Nullable<decimal> TaperLength { get; set; }
        public Nullable<decimal> ThreadLength { get; set; }
        public Nullable<decimal> NotchLength { get; set; }
        public Nullable<decimal> NotchUpTolerance { get; set; }
        public Nullable<decimal> NotchDownTolerance { get; set; }
        public decimal Price { get; set; }
        public int ItemStatus { get; set; }
        public Nullable<decimal> GFOdBas { get; set; }
        public Nullable<decimal> GFOdUpTolerance { get; set; }
        public Nullable<decimal> GFOdDownTolerance { get; set; }
        public Nullable<decimal> GFMinBas { get; set; }
        public Nullable<decimal> GFMinUpTolerance { get; set; }
        public Nullable<decimal> GFMinDownTolerance { get; set; }
    
        public virtual StandardSet StandardSet { get; set; }
    }
}
