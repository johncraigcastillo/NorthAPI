using NorthAPI.Models;

namespace NorthAPI.Extensions;

public static class FoodItemDtoExtensions
{
    public static FoodItem ToFoodItem(this FoodItemDto dto)
    {
        return new FoodItem(
            ingredients: dto.Ingredients,
            quantities: dto.Quantities,
            technique: dto.Technique)
        {
            Id = dto.Id,
            FoodCategoryId = dto.FoodCategoryId,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl
        };
    }
}