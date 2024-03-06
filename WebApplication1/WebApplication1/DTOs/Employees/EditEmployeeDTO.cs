using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Employees
{
    public class EditEmployeeDTO
    {
        [Required(ErrorMessage = "First name is required !")]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Last name is required !")]
        [StringLength(50)]
        public string lastName { get; set; }
    }
}
