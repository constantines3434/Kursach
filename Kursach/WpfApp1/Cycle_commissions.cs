//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cycle_commissions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cycle_commissions()
        {
            this.Protocols = new HashSet<Protocols>();
        }
    
        public int id_cycle_commission { get; set; }
        public Nullable<int> id_chairman_pck { get; set; }
        public Nullable<int> id_teacher { get; set; }
        public string code_speciality { get; set; }
    
        public virtual Chairman_pck Chairman_pck { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocols> Protocols { get; set; }
    }
}
