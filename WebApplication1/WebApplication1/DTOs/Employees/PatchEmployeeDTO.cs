using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Employees
{
    public class PatchEmployeeDTO
    {
        [Required(ErrorMessage = "Status is required !")]
        public bool status { get; set; }
    }
}
