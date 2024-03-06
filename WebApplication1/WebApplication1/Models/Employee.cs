using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEmployee { get; set; }
        [Required(ErrorMessage ="First name is required !")]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Last name is required !")]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required(ErrorMessage = "CIN is required !")]
        [StringLength(10)]
        public string cin { get; set; }
        [Required(ErrorMessage = "Status is required !")]
        public bool status { get; set; }
    }
}
