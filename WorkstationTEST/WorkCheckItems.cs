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
    
    public partial class WorkCheckItems
    {
        public System.Guid CheckId { get; set; }
        public System.Guid WorkId { get; set; }
        public string CheckNo { get; set; }
        public string CheckName { get; set; }
        public string CheckNorm { get; set; }
    
        public virtual WorkItems WorkItems { get; set; }
    }
}
