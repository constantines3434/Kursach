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
    
    public partial class Komplect_tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Komplect_tickets()
        {
            this.Tickets = new HashSet<Tickets>();
        }
    
        public int nom_komplect { get; set; }
        public Nullable<int> nom_kurs { get; set; }
        public Nullable<int> nom_semester { get; set; }
        public Nullable<int> nom_protocol { get; set; }
        public Nullable<int> id_examiners { get; set; }
    
        public virtual Examiners Examiners { get; set; }
        public virtual Kurs Kurs { get; set; }
        public virtual Protocols Protocols { get; set; }
        public virtual Semesters Semesters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
