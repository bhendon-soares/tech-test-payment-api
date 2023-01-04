using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {

        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet("BuscarVenda{id}")]
        public IActionResult BuscarVenda(int id)
        {
            var venda = _context.Vendas.Find(id);

            if(venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPost("RegistrarVenda")]
        public IActionResult RegistrarVenda(Venda venda)
        {
            if(venda.DescricaoProdutoVenda == null)
                return BadRequest(new { Erro = "Para registar a venda é necessário ter pelo menos 1 item" });

            if(venda.StatusVenda != EnumStatusVenda.AguardandoPagamento)
                return BadRequest(new { Erro = $"O status inicial da venda não pode ser alterado" });

            else if(venda.DataVenda == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da venda não pode ser vazia" });

            _context.Add(venda);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("AprovarPagamento{id}")]
        public IActionResult AprovarPagamentoVenda(int id)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if(vendaBanco == null)
                return NotFound();

            if(vendaBanco.StatusVenda == EnumStatusVenda.AguardandoPagamento)
            {
                vendaBanco.StatusVenda = EnumStatusVenda.PagamentoAprovado;
            }
            else
            {
                return BadRequest(new { Erro = $"É necessário que a venda esteja aguardando pagamento! O status atual desta venda é: {vendaBanco.StatusVenda}" });
            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok(vendaBanco);
        }

        [HttpPut("EnviarParaTranportadora{id}")]
        public IActionResult EnviarVendaParaTransportadora(int id)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if(vendaBanco == null)
                return NotFound();

            if(vendaBanco.StatusVenda == EnumStatusVenda.PagamentoAprovado)
            {
                vendaBanco.StatusVenda = EnumStatusVenda.EnviadoParaTransportadora;
            }
            else
            {
                return BadRequest(new { Erro = $"É necessário que a venda esteja com o pagamento aprovado! O status atual desta venda é: {vendaBanco.StatusVenda}" });
            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok(vendaBanco);
        }

        [HttpPut("EntregarVenda{id}")]
        public IActionResult EntregarVenda(int id)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if(vendaBanco == null)
                return NotFound();

            if(vendaBanco.StatusVenda == EnumStatusVenda.EnviadoParaTransportadora)
            {
                vendaBanco.StatusVenda = EnumStatusVenda.Entregue;
            }
            else
            {
                return BadRequest(new { Erro = $"É necessário que a venda esteja com a transportadora! O status atual desta venda é: {vendaBanco.StatusVenda}" });
            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok(vendaBanco);
        }

        [HttpPut("CancelarVenda{id}")]
        public IActionResult CancelarVenda(int id)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if(vendaBanco.StatusVenda == EnumStatusVenda.AguardandoPagamento || vendaBanco.StatusVenda == EnumStatusVenda.PagamentoAprovado)
            {
                vendaBanco.StatusVenda = EnumStatusVenda.Cancelada;
            }
            else
            {
                return BadRequest(new { Erro = $"É necessário que a venda esteja aguardando pagamento ou aprovada! O status atual desta venda é: {vendaBanco.StatusVenda}" });
            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok(vendaBanco);
        }
    }
}