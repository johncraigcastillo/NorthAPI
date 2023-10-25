namespace NorthAPI.Models;

public class FoodItem : BaseFoodItem
{
    public FoodItem(string ingredients, string quantities, string technique)
    {
        IngredientsList = ingredients.Split("; ").ToList();
        QuantitiesList = quantities.Split("; ").ToList();
        TechniqueList = technique.Split("; ").ToList();
    }


    public int FoodCategoryId { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public IEnumerable<string> IngredientsList { get; private set; }
    public IEnumerable<string> QuantitiesList { get; private set; }
    public IEnumerable<string> TechniqueList { get; private set; }
}