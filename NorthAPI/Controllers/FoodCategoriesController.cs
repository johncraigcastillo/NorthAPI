using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NorthAPI.Models;

namespace NorthAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodCategoriesController : ControllerBase
{
    private readonly MySqlConnection _connection;

    public FoodCategoriesController(MySqlConnection connection)
    {
        _connection = connection;
    }

    [HttpGet]
    public async Task<IEnumerable<FoodCategory>> GetFoodCategories()
    {
        const string queryText =
            """
            SELECT id as Id,
            name as Name
            FROM FoodCategories;
            """;
        var result = await _connection.QueryAsync<FoodCategory>(queryText);
        return result;
    }
}