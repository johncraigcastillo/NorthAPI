using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthAPI.Models;

public class FoodCategory
{
    public required int FoodCategoryId { get; set; }

    public required string FoodCategoryName { get; set; }
}