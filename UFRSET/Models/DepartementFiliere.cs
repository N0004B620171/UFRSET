namespace UFRSET.Models
{
    public class DepartementFiliere
    {
        public int Id { get; set; }
        public int DepartementId { get; set; }
        public int FiliereId { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual Filiere Filiere { get; set; }
    }

}
