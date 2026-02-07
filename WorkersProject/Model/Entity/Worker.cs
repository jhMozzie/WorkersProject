using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkersProject.Model.Entity
{
    [Table("Workers")]
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 60 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 60 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Document Type is required")]
        [StringLength(20, ErrorMessage = "Document Type can't be longer than 20 characters")]
        public string DocumentType { get; set; }
        [Required(ErrorMessage = "Document Number is required")]
        [StringLength(20, ErrorMessage = "Document Number can't be longer than 20 characters")]
        public string DocumentNumber { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(1)]
        [RegularExpression("^[MF]$", ErrorMessage = "Genter must be M or F")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Birth Date is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
