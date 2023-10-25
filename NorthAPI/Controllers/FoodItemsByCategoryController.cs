using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NorthAPI.Models;

namespace NorthAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodItemsByCategoryController : ControllerBase
{
    private readonly MySqlConnection _connection;

    public FoodItemsByCategoryController(MySqlConnection connection)
    {
        _connection = connection;
    }

    [HttpGet]
    public async Task<IEnumerable<BaseFoodItem>?> GetFoodItem(int desiredFoodCategoryId)
    {
        const string sql = """
                           SELECT
                               id, name
                            FROM
                                FoodItems
                            WHERE
                                food_category_id = @foodCategoryId
                           """;


        var foodItems = await _connection.QueryAsync<BaseFoodItem>(sql, new { foodCategoryId = desiredFoodCategoryId });

        return foodItems;
    }
}