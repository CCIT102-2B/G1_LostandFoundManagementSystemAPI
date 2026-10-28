using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CreateItemModel
    {
        [Required]
        public string ItemName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Lost";
    }
}