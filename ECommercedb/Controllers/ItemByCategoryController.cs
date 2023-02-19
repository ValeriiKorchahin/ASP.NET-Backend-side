using Dapper;
using ECommercedb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ECommercedb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemByCategoryController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ItemByCategoryController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{categoryId}")]

        public ActionResult GetAllItemsByCategory(int currentPageNumber, int pageSize, int categoryId)
        {
            int maxPageSize = 6;

            pageSize = pageSize < maxPageSize ? pageSize : maxPageSize;

            int skip = (currentPageNumber - 1) * pageSize;

            int take = pageSize;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var reader = connection.QueryMultiple(@"select Count(*) from item select * from item join category on itemcategoryid = category.id where itemcategoryid = @categoryId order by item.id offset @Skip rows fetch next @Take rows only",
                    new { Skip = skip, Take = take, categoryId = categoryId});

                int totalCount = reader.Read<int>().FirstOrDefault(); ;

                List<ItemsByCategory> items = reader.Read<ItemsByCategory>().ToList();

                var result = new ItemByCategoryResponse<List<ItemsByCategory>>(totalCount, items, currentPageNumber, pageSize);

                return Ok(result);
            }

        }

    }
}

