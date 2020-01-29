using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ngx_datatable_api.Models
{
    public class PaginationModel
    {
        public PaginationModel() { }

        public PaginationModel(int pageSize, int pageNumber) {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => TotalRecords / PageSize;
        public List<ExpandoObject> Data { get; set; }

        public void SetTotalRecords(int total) => TotalRecords = total;
        public void SetData(List<ExpandoObject> data) => Data = data;
    
        public void PagedList() {
            Data = Data.Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }
    }
}
