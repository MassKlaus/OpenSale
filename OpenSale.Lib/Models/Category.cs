namespace OpenSale.Lib.Models;

public class Record
{
    public DateTime CreatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}

public class EditableRecord : Record
{
    public DateTime ModifiedAt { get; set; }
}

public class TagCategory : Record
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual List<Tag> Tags { get; set; } = [];
}

public class Tag : Record
{
    public int TagCategoryId { get; set; }
    public TagCategory? TagCategory { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class Product : EditableRecord
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public double Weight { get; set; }

    public string Description { get; set; } = string.Empty;

    public decimal SalePrice { get; set; }

    public virtual List<Tag> Tags { get; set; } = [];
    public virtual List<Stock> Stocks { get; set; } = [];
}

public class Stock : EditableRecord
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public decimal PurchaseCost { get; set; }
    public int Amount { get; set; }

    public decimal UnitCost => PurchaseCost / Amount;
}

public class Audit : Record
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;
}