 
namespace HuseManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Debts
    {
        public int DebtID { get; set; }
        public int Owner { get; set; }
        public Nullable<double> WaterDebt { get; set; }
        public Nullable<double> ElectricityDebt { get; set; }
    
        public virtual Owners Owners { get; set; }
    }
}
