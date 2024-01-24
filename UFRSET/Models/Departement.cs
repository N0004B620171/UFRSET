using System.ComponentModel.DataAnnotations;

namespace UFRSET.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }
        public string NomDepartement { get; set; }
        public virtual ICollection<Filiere> Filieres { get; set; }
        public virtual ICollection<Per> Pers { get; set; }
        public virtual ICollection<Vacataire> Vacataires { get; set; }
    }

}
