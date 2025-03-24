using System.ComponentModel.DataAnnotations;

namespace DovetailSol.Models
{
    public class EMP
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Designation { get; set; }

        public string Reporting { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        [Required]
            
        public String City { get; set; }
    }
}
