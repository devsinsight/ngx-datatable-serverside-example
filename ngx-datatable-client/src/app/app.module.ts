import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";
import { DatatableComponent } from "./components/datatable/datatable.component";
import { CustomHttpService } from "./services/custom-http.service";
import { DatatableService } from "./components/datatable.service";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
  declarations: [AppComponent, DatatableComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgxDatatableModule
  ],
  providers: [CustomHttpService, DatatableService],
  bootstrap: [AppComponent]
})
export class AppModule {}
