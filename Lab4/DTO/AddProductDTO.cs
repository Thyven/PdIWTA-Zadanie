using System.ComponentModel.DataAnnotations;

namespace Lab4.DTO
{
    public class AddProductDTO
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
