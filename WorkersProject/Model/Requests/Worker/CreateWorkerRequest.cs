using System.ComponentModel.DataAnnotations;

namespace WorkersProject.Model.Requests.Worker
{
    public class CreateWorkerRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        public string DocumentNumber { get; set; }

        [Required]
        [RegularExpression("^[MF]$")]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string? Photo { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
    }
}