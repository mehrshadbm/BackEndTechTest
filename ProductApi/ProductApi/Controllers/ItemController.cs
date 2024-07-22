using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private static readonly List<Item> Items = new List<Item>
    {

        // here is where the mock data should be placed. please see the README PDF
        
        new Item { Id = 1, Sku = "170-10-8596", Name = "Birch", Price = 960.3, Attribute = new Attribute { Fantastic = new Fantastic { Value = true, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 2.7 } } },
        new Item { Id = 2, Sku = "370-04-2494", Name = "Cocoa butter, Phenylephrine HCl, Shark liver oil", Price = 983.7, Attribute = new Attribute { Fantastic = new Fantastic { Value = true, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 2.0 } } },
        new Item { Id = 3, Sku = "470-21-1561", Name = "simvastatin", Price = 196.75, Attribute = new Attribute { Fantastic = new Fantastic { Value = true, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 4.0 } } },
        new Item { Id = 4, Sku = "692-14-7432", Name = "Lisinopril", Price = 948.6, Attribute = new Attribute { Fantastic = new Fantastic { Value = false, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 2.5 } } },
        new Item { Id = 5, Sku = "975-96-8935", Name = "Nicotine polacrilex", Price = 137.53, Attribute = new Attribute { Fantastic = new Fantastic { Value = false, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 2.1 } } },
        new Item { Id = 6, Sku = "125-66-8353", Name = "Simvastatin", Price = 507.08, Attribute = new Attribute { Fantastic = new Fantastic { Value = true, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 1.3 } } },
        new Item { Id = 7, Sku = "993-77-0178", Name = "Miconazole nitrate", Price = 714.1, Attribute = new Attribute { Fantastic = new Fantastic { Value = true, Type = 1, Name = "fantastic" }, Rating = new Rating { Name = "rating", Type = "2", Value = 1.7 } } }
    };

    [HttpGet]
    public IActionResult GetItems([FromQuery] double? minPrice, [FromQuery] double? maxPrice, [FromQuery] bool? fantastic, [FromQuery] double? minRating, [FromQuery] double? maxRating)
    {

        // to let our list item be queriable only when needed ->
        var filteredItems = Items.AsQueryable();


        // HasValue was used so we make sure the quercy is executed only if the filter has a value
        if (minPrice.HasValue)
        {
            filteredItems = filteredItems.Where(i => i.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            filteredItems = filteredItems.Where(i => i.Price <= maxPrice.Value);
        }

        if (fantastic.HasValue)
        {
            filteredItems = filteredItems.Where(i => i.Attribute.Fantastic.Value == fantastic.Value);
        }

        if (minRating.HasValue)
        {
            filteredItems = filteredItems.Where(i => i.Attribute.Rating.Value >= minRating.Value);
        }

        if (maxRating.HasValue)
        {
            filteredItems = filteredItems.Where(i => i.Attribute.Rating.Value <= maxRating.Value);
        }

        return Ok(filteredItems);
    }
}
