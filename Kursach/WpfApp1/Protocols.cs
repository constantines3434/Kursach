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
    
    public partial class Protocols
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Protocols()
        {
            this.Komplect_tickets = new HashSet<Komplect_tickets>();
        }
    
        public int nom_protocol { get; set; }
        public Nullable<System.DateTime> date_protocol { get; set; }
        public Nullable<int> id_cycle_commission { get; set; }
    
        public virtual Cycle_commissions Cycle_commissions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komplect_tickets> Komplect_tickets { get; set; }
    }
}
