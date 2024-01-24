using System.ComponentModel.DataAnnotations;

namespace UFRSET.Models
{
    public class Filiere
    {
        public int FiliereId { get; set; }
        public string NomFiliere { get; set; }
        public virtual ICollection<Departement> Departements { get; set; }
    }

}
