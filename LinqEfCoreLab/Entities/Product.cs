namespace LinqEfCoreLab.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Product(){  }

    public static Product Create(
        string name,
        string description,
        decimal price,
        int stockQuantity
    )
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = stockQuantity,
            CreatedAt = DateTime.UtcNow
        };
        return product;
    }

        public void Update(
        string name,
        string description,
        decimal price,
        int stockQuantity
    )
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        UpdatedAt = DateTime.UtcNow;
    }
    
}