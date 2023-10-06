using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleAPI.Entities
{
    public class Order
    {
        [JsonIgnore]
        [Key]
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EntryDate { get; set; }

        [Required, MaxLength(100), MinLength(2)]        
        public string? Name { get; set; }

        [Required, MaxLength(100), MinLength(2)]
        public string? Description { get; set; }

        public bool IsInvoiced { get; set; } = true;

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
