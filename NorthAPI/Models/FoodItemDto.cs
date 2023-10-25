namespace NorthAPI.Models;

public class FoodItemDto : BaseFoodItem
{
    public string? Description { get; set; }
    public string? Ingredients { get; set; }
    public string? Quantities { get; set; }
    public string? Technique { get; set; }
    public int FoodCategoryId { get; set; }
    public string? ImageUrl { get; set; }
}