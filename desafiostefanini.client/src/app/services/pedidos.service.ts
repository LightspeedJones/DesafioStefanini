import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class PedidosService {
  constructor(private http: HttpClient) { }

  private url = 'https://localhost:7297/pedidos'

  loadPedidos(): Observable<any>{
    return this.http.get(`${this.url}/GetPedidos`)
  }

  criarPedido(data: any): Observable<any>{
    return this.http.post(`${this.url}/CriarPedido`, data)
  }

  loadProdutos(): Observable<any>{
    return this.http.get(`${this.url}/GetProdutos`)
  }

  deletePedido(id: any): Observable<any>{
    return this.http.delete(`${this.url}/DeletarPedido/${id}`)
  }

  loadPedidoPorId(id: any): Observable<any>{
    return this.http.get(`${this.url}/GetPedidoPorId/${id}`)
  }

  updatePedido(data: any){
    return this.http.put(`${this.url}/AtualizarPedido`, data)
  }
}
