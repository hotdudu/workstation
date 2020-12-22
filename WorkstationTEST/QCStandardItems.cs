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
    
    public partial class QCStandardItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QCStandardItems()
        {
            this.AssemblyItems = new HashSet<AssemblyItems>();
        }
    
        public int TenantId { get; set; }
        public System.Guid QCStandardId { get; set; }
        public System.Guid QCStandardItemId { get; set; }
        public string SubMakeNo { get; set; }
        public string DisplyName { get; set; }
        public string DesignType { get; set; }
        public Nullable<System.Guid> CreateUserId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.Guid> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string HRC { get; set; }
        public Nullable<System.Guid> MeasuredUserId { get; set; }
        public Nullable<System.DateTime> MeasuredDate { get; set; }
        public Nullable<decimal> ThreePinOd { get; set; }
        public string MeasuredPressure { get; set; }
        public Nullable<decimal> OdBasValueX { get; set; }
        public Nullable<decimal> OdBasValueY { get; set; }
        public Nullable<decimal> OdBasValueX1 { get; set; }
        public Nullable<decimal> OdBasValueY1 { get; set; }
        public Nullable<decimal> OdBasValueX2 { get; set; }
        public Nullable<decimal> OdBasValueY2 { get; set; }
        public Nullable<decimal> OdBasValueX3 { get; set; }
        public Nullable<decimal> OdBasValueY3 { get; set; }
        public Nullable<decimal> MinBasValueX { get; set; }
        public Nullable<decimal> MinBasValueY { get; set; }
        public Nullable<decimal> MinBasValueX1 { get; set; }
        public Nullable<decimal> MinBasValueY1 { get; set; }
        public Nullable<decimal> MinBasValueX2 { get; set; }
        public Nullable<decimal> MinBasValueY2 { get; set; }
        public Nullable<decimal> MinBasValueX3 { get; set; }
        public Nullable<decimal> MinBasValueY3 { get; set; }
        public Nullable<int> AngleValueR { get; set; }
        public Nullable<int> AngleValue { get; set; }
        public Nullable<int> AngleValueL { get; set; }
        public Nullable<decimal> PitchToleranceValue { get; set; }
        public Nullable<decimal> Temperature1 { get; set; }
        public Nullable<decimal> Temperature2 { get; set; }
        public Nullable<decimal> Humidity1 { get; set; }
        public Nullable<decimal> Humidity2 { get; set; }
        public Nullable<System.Guid> ReviewerEmployeeId { get; set; }
        public int Status { get; set; }
        public bool AssembledFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssemblyItems> AssemblyItems { get; set; }
    }
}
