using Dapper;
using ECommercedb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ECommercedb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CategoryController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            IEnumerable<Category> categories = await GetAllCategories(connection);
            return Ok(categories);
        }

        private static async Task<IEnumerable<Category>> SelectAllCategories(SqlConnection connection)
        {
            return await connection.QueryAsync<Category>("select * from category");
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int Id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var category = await connection.QueryFirstAsync<Category>("select * from category where ID = @Id", 
                new { Id = Id });
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> PostCategory(Category category)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into category (categoryname) values (@CategoryName)", category);
            return Ok(await GetAllCategories(connection));
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update category set categoryname = @CategoryName where ID = @Id", category);
            return Ok(await GetAllCategories(connection));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int Id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from category where ID = @Id", new { Id = Id });
            return Ok(await GetAllCategories(connection));
        }

        private static async Task<IEnumerable<Category>> GetAllCategories(SqlConnection connection)
        {
            return await connection.QueryAsync<Category>("select * from category");
        }



    }
}
