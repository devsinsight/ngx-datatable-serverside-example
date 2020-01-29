using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngx_datatable_api.Models
{
    public class PageModel
    {

        public PageModel() {

        }
        public PaginationModel Pagination { get; set; }
        public SortingModel Sorting { get; set; }


    }
}
