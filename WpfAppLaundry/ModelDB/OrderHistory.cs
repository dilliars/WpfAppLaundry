//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppLaundry.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderHistory
    {
        public int HistoryID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
    
        public virtual OrderStatuses OrderStatuses { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
