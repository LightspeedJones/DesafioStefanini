﻿using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Server.Controllers
{
    [ApiController]
    [Route("Pedidos")]
    public class StefController : ControllerBase
    {
        private readonly StefDbContext _context;
        private readonly IStefService _service;

        public StefController(StefDbContext context, IStefService stefService)
        {
            _context = context;
            _service = stefService;
        }

        [HttpGet("GetPedidos")]
        public IActionResult GetPedidos()
        {
            var pedidos = _service.GetPedidos();

            return Ok(pedidos);
        }

        [HttpGet("GetPedidoPorId/{id}")]
        public IActionResult GetPedidoPorId(int id)
        {
            var pedido = _service.GetPedidoPorId(id);

            if(pedido is null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost("CriarPedido")]
        public IActionResult CriarPedido(Pedido pedido)
        {
            if(pedido is null)
            {
                return BadRequest();
            }

            _service.CriarPedido(pedido);

            return Ok(pedido);
        }

        [HttpPut("AtualizarPedido")]
        public IActionResult AtualizarPedido(Pedido pedido)
        {
            if(pedido is null)
            {
                return BadRequest();
            }

            _service.AtualizarPedido(pedido);

            return Ok(pedido);
        }

        [HttpDelete("DeletarPedido/{id}")]
        public int DeletarPedido(int id)
        {
            return _service.DeletarPedido(id);
        }

        [HttpGet("GetProdutos")]
        public IActionResult GetProdutos()
        {
            var produtos = _service.GetProdutos();

            if(produtos is null)
            {
                return BadRequest();
            }

            return Ok(produtos);
        }

    }
}
