//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amirhanov_Exam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int ReportID { get; set; }
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public string Description { get; set; }
        public string Consumables { get; set; }
        public System.DateTime ReportDate { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
