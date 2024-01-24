using System.ComponentModel.DataAnnotations;

namespace UFRSET.Models
{
    public class Vacataire
    {
        public int VacataireId { get; set; }
        public string NomVacataire { get; set; }
        public string Specialite { get; set; }
        public int DepartementId { get; set; }
        public int ServiceId { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual Service Service { get; set; }
    }

}
