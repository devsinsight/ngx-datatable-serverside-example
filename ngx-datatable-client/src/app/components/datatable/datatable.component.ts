import { Component, OnInit } from "@angular/core";
import { ColumnMode, TableColumn } from "@swimlane/ngx-datatable";
import { ClientModel } from "src/app/models/client.model";
import { PaginationModel } from "src/app/models/pagination.model";
import { DatatableService } from "../datatable.service";
import { SortingModel } from "src/app/models/sorting.model";

@Component({
  selector: "app-datatable",
  templateUrl: "./datatable.component.html",
  styleUrls: ["./datatable.component.scss"]
})
export class DatatableComponent implements OnInit {
  page = new PaginationModel();
  sort = new SortingModel();
  rows: Array<ClientModel>;
  columns: Array<TableColumn>;

  ColumnMode = ColumnMode;

  constructor(private service: DatatableService) {}

  ngOnInit() {
    this.columns = [
      { name: "ID", prop: "id", width: 50 },
      { name: "Name", prop: "name", width: 100 },
      { name: "Address", prop: "address", width: 350 }
    ];
    this.setPage({ offset: 0 });
  }

  setPage(pageInfo) {
    this.page.pageNumber = pageInfo.offset;
    this.service
      .getData({ pagination: this.page, sorting: this.sort })
      .subscribe((response: any) => {
        this.rows = response.pagination.data;
        this.sort = response.sorting;
        this.page = response.pagination;
        console.log(this.page);
      });
  }

  onSort(event) {
    console.log("Sort Event", event);

    this.sort.SortColumn = event.sorts[0].prop;
    this.sort.SortDirection = event.sorts[0].dir;
    this.page.pageNumber = 0;
    this.service
      .getData({ sorting: this.sort, pagination: this.page })
      .subscribe((response: any) => {
        this.rows = response.pagination.data;
        this.page = response.pagination;
        this.sort = response.sorting;
        console.log(this.page);
      });
  }
}
