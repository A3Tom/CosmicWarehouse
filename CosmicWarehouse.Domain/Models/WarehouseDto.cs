using System.ComponentModel.DataAnnotations;

namespace CosmicWarehouse.Domain.Models
{
    public class WarehouseDto
    {
        public int? Id { get; init; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
