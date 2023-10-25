using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NorthAPI.Extensions;
using NorthAPI.Models;

namespace NorthAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodItemController : ControllerBase
{
    private readonly MySqlConnection _connection;

    public FoodItemController(MySqlConnection connection)
    {
        _connection = connection;
    }

    [HttpGet]
    public async Task<FoodItem?> GetFoodItem(int desiredFoodItemId)
    {
        const string sql = """
                           SELECT
                                FI.id AS Id,
                                FI.name AS Name,
                                FI.description AS Description,
                                FI.food_category_id AS FoodCategoryId,
                                FI.image_url AS ImageUrl,
                                (SELECT GROUP_CONCAT(name ORDER BY step ASC SEPARATOR '; ') FROM FoodItem_Ingredients FII JOIN FoodIngredients FIngr ON FII.food_ingredient_id = FIngr.id WHERE FI.id = FII.food_item_id) AS Ingredients,
                                (SELECT GROUP_CONCAT(quantity ORDER BY step ASC SEPARATOR '; ') FROM FoodItem_Ingredients WHERE FI.id = food_item_id) AS Quantities,
                                (SELECT GROUP_CONCAT(description ORDER BY step ASC SEPARATOR '; ') FROM FoodItem_Technique WHERE FI.id = food_item_id) AS Technique
                            FROM
                                FoodItems FI
                            WHERE
                                FI.id = @foodItemId
                           """;


        var response = await _connection.QueryAsync<FoodItemDto>(sql, new { foodItemId = desiredFoodItemId });
        var foodItem = response.Select(item => item.ToFoodItem()).FirstOrDefault();

        return foodItem;
    }
}