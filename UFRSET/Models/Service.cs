using System.ComponentModel.DataAnnotations;

namespace UFRSET.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string NomService { get; set; }
        public virtual ICollection<Per> Pers { get; set; }
        public virtual ICollection<Vacataire> Vacataires { get; set; }
    }

}
