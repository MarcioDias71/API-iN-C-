using System;
using System.Collections.Generic;
using System.Globalization;

using System.Linq;
using Funcoes;
using Produtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
    [ApiController]
    
    [Route("[controller]")]
    public class Produto: Controller
    {


         [HttpGet("listar")]
     public object Get()
        {
           Funcao F = new Funcao();
           var lista = F.AcessarProdutos();
               
            return new{
                Lista = lista

            };
     
            
        }

        [HttpPost("adicionar/Nome={nome}/Preco={preco}/Custo={custo}")]
        public IActionResult Post(string nome, float preco, float custo){
            
            Funcao F = new Funcao();
            F.RegistrarProduto(nome, preco, custo);
            return Accepted();


        }
    

        [HttpGet("atualizar/Id={id}/Nome={nome}/Preco={preco}/Custo={custo}")]
        public IActionResult Put(string id, string nome, float preco, float custo){

            Funcao F = new Funcao();
            F.AtualizarProduto(id, nome, preco, custo);

                return Ok();
        }
        [HttpGet("excluir/{id}")]
        public IActionResult Delete(string id){

            Funcao F = new Funcao();
            F.ExcluirProduto(id);
                return Ok();


        }

            
        
        
    }
}
