using System.ComponentModel.DataAnnotations;

namespace BackendStageTwo.Models
{
    public class MathematicalOperationRequestModel
    {
        [Required]
        public int x { get; set; }

        [Required]
        public int y { get; set; }

        [Required]
        public string? operation_type { get; set; }
    }
}