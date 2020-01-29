using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using ngx_datatable_api.Models;
using Newtonsoft.Json;
using System.Dynamic;
using Microsoft.Extensions.Caching.Memory;

namespace ngx_datatable_api.Controllers
{
    [Route("[controller]")]
    public class DatatableController : Controller
    {
        private IMemoryCache _memoryCache;

        public DatatableController(IMemoryCache memoryCache) {
            _memoryCache = memoryCache;
        }
            
        private List<ExpandoObject> GetDummyData() {
            var cacheData = _memoryCache.GetOrCreate("dummy", (entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(1);

                var data = new List<ExpandoObject>();
                var faker = new Faker();
                for (int i = 0; i <= 6000; i++)
                {
                    dynamic item = new ExpandoObject();
                    item.id = i + 1;
                    item.name = faker.Person.FirstName;
                    item.address = faker.Address.StreetAddress();
                    data.Add(item);
                }

                return data;
            });

            return cacheData;
        }

        [HttpPost("data")]
        public IActionResult GetPagedData([FromBody] PageModel model)
        {

            var data = GetDummyData();
            model.Pagination = new PaginationModel(model.Pagination.PageSize, model.Pagination.PageNumber);
            model.Pagination.SetTotalRecords(data.Count());
            model.Sorting = new SortingModel(model.Sorting.SortDirection, model.Sorting.SortColumn, data);
            model.Sorting.SortList();
            model.Pagination.SetData(model.Sorting.Data);

            model.Pagination.PagedList();

            return Ok(model);
        }

        
    }
}