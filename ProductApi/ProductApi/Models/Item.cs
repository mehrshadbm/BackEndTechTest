
//Parent Class
public class Item
{
    public int Id { get; set; }
    public required string Sku { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public required Attribute Attribute { get; set; }
}



// Child Classes

public class Attribute
{
    public required Fantastic Fantastic { get; set; }
    public required Rating Rating { get; set; }
}

public class Fantastic
{
    public bool Value { get; set; }
    public int Type { get; set; }
    public required string Name { get; set; }
}

public class Rating
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public double Value { get; set; }
}
