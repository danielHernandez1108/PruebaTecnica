using System.ComponentModel.DataAnnotations;


namespace Dominio.Models
{
    public class Patient
    {
        public int? Id { get; set; } = 0;

        [Required]
        [StringLength(120, ErrorMessage = "{0} puede cantidad de caracteres entre {2} y {1}.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(120, ErrorMessage = "{0} puede cantidad de caracteres entre {2} y {1}.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "{0} puede cantidad de caracteres entre {2} y {1}.", MinimumLength = 2)]
        public string Document { get; set; }

        [Required]
        public int TypeDocument { get; set; }

        [StringLength(15, ErrorMessage = "{0} puede cantidad de caracteres entre {2} y {1}.", MinimumLength = 1)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(15, ErrorMessage = "{0} puede cantidad de caracteres entre {2} y {1}.", MinimumLength = 10)]
        public string Address { get; set; } = string.Empty;
        public int Sex { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "{0} puede cantidad de caracteres entre {2} y {1}.", MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string BirthDate { get; set; } = string.Empty;
    }

    public class Document
    {
        [Required]
        public int IdDocument { get; set; }
        public string Description { get; set; }
    };

}
