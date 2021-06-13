using System;
using System.Linq;
namespace Produtos
{
    public class Produto
    {

    public Produto()
    {
        
    }
    public Produto(string nome, float preco, float custo ){
       this.Nome = nome;
       this.Preco = preco;
       this.Custo = custo;
       GeraId();
    } 
    
     public string Id { get; set; }
     public string Nome {get; set;}
     public float Preco {get; set;}
     public float Custo {get; set;}

    

    private  void GeraId(){

    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    var random = new Random();
    var result = new string(
    Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
    this.Id = result;
  
    }
}

}
