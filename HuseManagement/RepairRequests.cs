 
namespace HuseManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class RepairRequests
    {
        public int RequestID { get; set; }
        public int Address { get; set; }
        public int ApartmentNumber { get; set; }
        public string ProblemDescription { get; set; }
        public int ResponsibleEmployee { get; set; }
        public string RequestStatus { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Owners Owners { get; set; }
    }
}
