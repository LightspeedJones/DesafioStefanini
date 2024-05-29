import { Component, OnInit } from '@angular/core';
import { PedidosService } from '../services/pedidos.service';
import { MenuItem, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-view-pedidos',
  templateUrl: './view-pedidos.component.html',
  styleUrl: './view-pedidos.component.css'
})

export class ViewPedidosComponent implements OnInit{
  constructor(
    private pedidoService: PedidosService,
    private builder: FormBuilder,
    private messageService: MessageService
  ) {}

  items: MenuItem[]
  visible: boolean = false
  nomeCliente: any
  emailCliente: any
  form: FormGroup
  produtos: any
  itensSelecionados: any[] = []
  pedidos: any
  idPedidoEditar: any
  headerDialog: any
  edicao: boolean = false

  ngOnInit(): void {
    this.getPedidos()
    this.getProdutos()

    this.form = this.builder.group({
      id: 0,
      nomeCliente: null,
      emailCliente: null,
      pago: true,
      itensPedido: this.builder.array([])
    })
  }

  public showToastErro(){
    this.messageService.add({severity: 'error', summary: 'Erro', detail: 'Item selecionado não pode ter quantidade menor que zero'})
  }

  public showToastSucesso(message: any){
    this.messageService.add({severity: 'success', summary: 'Sucesso', detail: message})
  }

  private getProdutos(){
    this.pedidoService.loadProdutos().subscribe(data => {
      this.produtos = data
    })
  }

  private getPedidos(){
    this.pedidoService.loadPedidos().subscribe(data => {
      this.pedidos = data
    })
  }

  public adicionarItensPedido(prod: any){
    if(this.itensSelecionados.find(e => e.idProduto == prod.id)){
      this.itensSelecionados.splice(this.itensSelecionados.findIndex(e => e.idProduto === prod.id), 1)
      return
    }

    let qt = (<HTMLInputElement>document.getElementById(`drop${prod.id}`)).getElementsByTagName('span')[0].innerText

    let itemPedido = {
      id: 0,
      idProduto: prod.id,
      quantidade: qt
    }

    this.itensSelecionados.push(itemPedido)
  }

  changeDropValue(event: any, item: any){
    (<HTMLInputElement>document.getElementById(`drop${item.id}`)).getElementsByTagName('span')[0].innerHTML = event.value
    let index = this.itensSelecionados.findIndex(e => e.idProduto === item.id)
    this.itensSelecionados[index].quantidade = event.value

  }

  public async editarPedido(item: any){
    this.edicao = true
    this.itensSelecionados = []
    this.headerDialog = 'Editar pedido'
    this.idPedidoEditar = item.id
    
    this.visible = true
    this.nomeCliente = item.nomeCliente
    this.emailCliente = item.emailCliente
  }

  public async setarValores(){
    let pedidoEditar: any = await this.getPedidoPorId(this.idPedidoEditar)
    pedidoEditar.itensPedido.forEach((i: any) => {
      let teste = (<HTMLInputElement>document.getElementById(`drop${i.idProduto}`)).value;
      console.log(teste);
      (<HTMLInputElement>document.getElementById(`drop${i.idProduto}`)).getElementsByTagName('span')[0].innerHTML = i.quantidade;
      (<HTMLInputElement>document.getElementById(`check${i.idProduto}`)).checked = true
    })

    let obj: any
    pedidoEditar.itensPedido.forEach(i => {
      obj = {
        id: 0,
        idProduto: i.idProduto,
        quantidade: i.quantidade
      }
      
      this.itensSelecionados.push(obj)
    })
  }

  public async getPedidoPorId(id: any){
    return new Promise((resolve) => {
      this.pedidoService.loadPedidoPorId(id).subscribe({
        next: (data: any) => {
          resolve(data)
        },
        error: (data: any) => {
          console.log(data)
        }
      })
    })
  }

  public exibirModalPedido(){
    this.itensSelecionados = []
    this.headerDialog = 'Criar pedido'
    this.visible = true
    this.clearForm()
  }

  public fecharDialog(){
    this.visible = false
  }

  public clearForm(){
    this.nomeCliente = ""
    this.emailCliente = ""
  }

  public async salvarPedido(editar: boolean){
    if(!this.nomeCliente || !this.emailCliente){
      return
    }

    let erro = false

    this.itensSelecionados.forEach(item => {
      if(item.quantidade == 0){
        erro = true
      }
    })

    if(erro){
      this.showToastErro()
      return
    }

    this.form.value.nomeCliente = this.nomeCliente
    this.form.value.emailCliente = this.emailCliente
    this.form.value.itensPedido = this.itensSelecionados

    if(editar){
      this.form.value.id = this.idPedidoEditar
      await this.updatePedido(this.form.value)
    }else{
      await this.criarPedido(this.form.value)
    }
  }
  
  public async criarPedido(model: any){
    return new Promise((resolve) => {
      this.pedidoService.criarPedido(model).subscribe({
        next: () => {
          this.visible = false
          this.showToastSucesso('Pedido criado com sucesso')
          this.getPedidos()
          resolve(true)
        },
        error: (data: any) => {
          console.log(data)
        }
      })
    })
  }

  public async updatePedido(model: any){
    return new Promise((resolve) => {
      this.pedidoService.updatePedido(this.form.value).subscribe({
        next: () => {
          this.visible = false
          this.showToastSucesso('Pedido editado com sucesso')
          this.getPedidos()
          resolve(true)
        },
        error: (data: any) => {
          console.log(data)
        }
      })
    })
  }
  

  public deletarPedido(item: any){
    this.pedidoService.deletePedido(item.id).subscribe({
      next: () => {
        this.showToastSucesso('Pedido deletado com sucesso')
        this.getPedidos()
      },
      error: (data: any) => {
        console.log(data)
      }
    })
  }
}
