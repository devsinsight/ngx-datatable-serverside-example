import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CustomHttpService {
  constructor(private http: HttpClient) {}

  get(utl) {
    return this.http.get(utl);
  }

  post(url, params) {
    return this.http.post(url, params);
  }
}
