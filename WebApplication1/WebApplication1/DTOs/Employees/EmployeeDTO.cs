using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Employees
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "First name is required !")]
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
