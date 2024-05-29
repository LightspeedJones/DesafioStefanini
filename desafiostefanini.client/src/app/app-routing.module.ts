import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewPedidosComponent } from './view-pedidos/view-pedidos.component';
import { FormPedidoComponent } from './form-pedido/form-pedido.component';

const routes: Routes = [
  {path: '', redirectTo: 'Home', pathMatch: 'full'},
  {path: 'Home', component: ViewPedidosComponent},
  {path: 'CriarPedido', component: FormPedidoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }