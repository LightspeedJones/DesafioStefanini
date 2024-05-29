import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PedidosService } from './services/pedidos.service';

// interface WeatherForecast {
//   date: string;
//   temperatureC: number;
//   temperatureF: number;
//   summary: string;
// }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  // public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient, private pedidoService: PedidosService) {}

  ngOnInit() {
    // this.getForecasts();
    this.getPedidos()
  }

  private getPedidos(){
    this.pedidoService.loadPedidos().subscribe(data => {
      console.log(data)
    })
  }

  // getForecasts() {
  //   this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
  //     (result) => {
  //       this.forecasts = result;
  //     },
  //     (error) => {
  //       console.error(error);
  //     }
  //   );
  // }

  title = 'Desafio Stefanini';
}
