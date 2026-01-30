
namespace HuseManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Houses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Houses()
        {
            this.Owners = new HashSet<Owners>();
        }
    
        public int HouseID { get; set; }
        public string Address { get; set; }
        public int NumberOfFloors { get; set; }
        public Nullable<int> NumberOfApartments { get; set; }
        public int YearBuilt { get; set; }
        public double Area { get; set; }
        public System.DateTime ManagementStartDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owners> Owners { get; set; }
    }
}
