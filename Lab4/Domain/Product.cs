using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    public class Product
    {
        public Product()
        {
        }

        public Product(Guid id, string name, bool isAvailable)
        {
            Id = id;
            Name = name;
            IsAvailable = isAvailable;
        }

        public Guid Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
