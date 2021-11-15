
namespace Principal
{
    using System;
    using System.Collections.Generic;
    
    public partial class curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public curso()
        {
            this.catedratico = new HashSet<catedratico>();
        }
    
        public int codigocurso { get; set; }
        public string nombrecurso { get; set; }
        public string creditos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catedratico> catedratico { get; set; }
    }
}
