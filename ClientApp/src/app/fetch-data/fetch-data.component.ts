import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";

@Component({
  selector: "app-fetch-data",
  styleUrls: ["fetch-data.component.css"],
  templateUrl: "./fetch-data.component.html",
})
export class FetchDataComponent {
  public forecasts: MatTableDataSource<WeatherForecast>;
  public displayedColumns = ["date", "temp. (C)", "temp. (F)", "summary"];

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + "api/weatherforecast").subscribe(
      (result) => {
        this.forecasts = new MatTableDataSource(result);
      },
      (error) => console.error(error)
    );
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
