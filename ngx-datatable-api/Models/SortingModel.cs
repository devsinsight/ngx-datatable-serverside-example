using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ngx_datatable_api.Models
{
    public class SortingModel
    {
        public SortingModel(string sortDirection, string sortColumn, List<ExpandoObject> data)
        {
            SortDirection = sortDirection;
            SortColumn = sortColumn;
            Data = data;
        }

        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<ExpandoObject> Data { get; set; }

        public void SortList() {
            if (!string.IsNullOrEmpty(SortColumn) && !string.IsNullOrEmpty(SortDirection))
            {
                Data = SortDirection == "asc" ? Data.OrderBy(p => ((IDictionary<string, object>)p)[SortColumn]).ToList() :
                    Data.OrderByDescending(p => ((IDictionary<string, object>)p)[SortColumn]).ToList();
            }
        }
    }
}
