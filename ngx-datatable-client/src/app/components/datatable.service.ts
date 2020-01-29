import { Injectable } from "@angular/core";
import { CustomHttpService } from "../services/custom-http.service";

@Injectable()
export class DatatableService {
  constructor(private service: CustomHttpService) {}

  getData(params) {
    return this.service.post("https://localhost:5001/datatable/data", params);
  }
}
