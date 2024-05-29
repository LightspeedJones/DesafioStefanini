import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { ViewPedidosComponent } from './view-pedidos/view-pedidos.component';
import { TableModule } from 'primeng/table';
import { MenubarModule } from 'primeng/menubar';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [
    ViewPedidosComponent,
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    AppRoutingModule,
    TableModule,
    MenubarModule,
    InputTextModule,
    FormsModule,
    ButtonModule,
    DialogModule,
    CheckboxModule,
    BrowserAnimationsModule,
    DropdownModule,
    ToastModule
  ],
  providers: [MessageService],
  bootstrap: [ViewPedidosComponent]
})
export class AppModule { }
