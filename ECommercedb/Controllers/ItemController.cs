using Dapper;
using ECommercedb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ECommercedb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ItemController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]

        public ActionResult GetAllItems(int currentPageNumber, int pageSize)
        {
            int maxPageSize = 6;

            pageSize = pageSize < maxPageSize ? pageSize : maxPageSize;

            int skip = (currentPageNumber - 1) * pageSize;

            int take = pageSize;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var reader = connection.QueryMultiple(@"select Count(*) from item select * from item order by ID offset @Skip rows fetch next @Take rows only",
                    new {Skip = skip, Take = take});

                int totalCount = reader.Read<int>().FirstOrDefault();

                List<Item> items = reader.Read<Item>().ToList();

               var result = new ItemResponse<List<Item>>(totalCount, items, currentPageNumber, pageSize);
               
                return Ok(result);
            }

        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<Item>> GetItemById(int Id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var item = await connection.QueryFirstAsync<Item>("select * from item where ID = @Id",
                new { Id = Id });
            return Ok(item);
        }

        [HttpPost]

        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into item (itemname, price, media, itemcategoryid) values (@ItemName, @Price, @Media, @ItemCategoryId)", item);
            return Ok(await GetAllItems(connection));
        }

        [HttpPut]

        public async Task<ActionResult<Item>> UpdateItem(Item item)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update item set itemname = @ItemName, price = @Price, media = @Media, itemcategoryid = @ItemCategoryId where ID = @Id", item);
            return Ok(await GetAllItems(connection));
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<Item>> DeleteItem(int Id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from item where ID = @Id", new { Id = Id });
            return Ok(await GetAllItems(connection));
        }

        private static async Task<IEnumerable<Item>> GetAllItems(SqlConnection connection)
        {
            return await connection.QueryAsync<Item>("select * from item");
        }
    }
}
