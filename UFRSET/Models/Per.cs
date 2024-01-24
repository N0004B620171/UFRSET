using System.ComponentModel.DataAnnotations;

namespace UFRSET.Models
{
    public class Per
    {
        public int PerId { get; set; }
        public string NomPer { get; set; }
        public string Specialite { get; set; }
        public int DepartementId { get; set; }
        public int ServiceId { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual Service Service { get; set; }
    }

}
