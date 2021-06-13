using System;
using BD;
using System.Linq;
using System.Data;
using Produtos;
using System.Data.SqlClient;
using System.Collections.Generic;  
namespace Funcoes
{

    public class Funcao
    {

        public void RegistrarProduto(string nome, float preco, float custo){

        
        
            Conexao C = new Conexao();
            Produto P = new Produto(nome, preco, custo);

            SqlCommand cmd = new SqlCommand("INSERT INTO Produto VALUES (@id, @nome, @preco, @custo)", C.MyConnection);
            SqlParameter  idParam = new SqlParameter("@id", SqlDbType.Text, 100);
            SqlParameter nomeParam = new SqlParameter("@nome", SqlDbType.Text, 100);
            SqlParameter precoParam = new SqlParameter("@preco", SqlDbType.Float);
            SqlParameter custoParam = new SqlParameter("@custo", SqlDbType.Float);
            
             idParam.Value = P.Id;
             nomeParam.Value= nome;
             precoParam.Value = preco;
             custoParam.Value = custo;
     
             cmd.Parameters.Add(idParam);
             cmd.Parameters.Add(nomeParam);
             cmd.Parameters.Add(precoParam);
             cmd.Parameters.Add(custoParam);


             cmd.Prepare();
            // SqlDataReader reader;
            cmd.ExecuteNonQuery();
            C.Fechar();
        }
        public List<Produto> AcessarProdutoPorId(string id){

            Conexao C = new Conexao();
            SqlCommand cmd = new SqlCommand("SELECT  *   FROM Produto where Id = CONVERT(Varchar, @id)", C.MyConnection);
            SqlParameter  idParam = new SqlParameter("@id", SqlDbType.Text, 50);
            idParam.Value = id;
            cmd.Parameters.Add(idParam);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Produto> Produto = new List<Produto>() ;
            
            if(reader.Read()){


        
            Produto P = new Produto( reader["Nome"].ToString(), float.Parse(reader["Preco_venda"].ToString()), float.Parse(reader["Custo"].ToString()));
            P.Id = reader["Id"].ToString();
            Produto.Add(P);
                   
            }
            
                reader.Close();
                cmd.ExecuteNonQuery();
                C.Fechar();
                return Produto;

        }


        public List<Produto> AcessarProdutos(){

            Conexao C = new Conexao();
            SqlCommand cmd = new SqlCommand("SELECT  *   FROM Produto  ", C.MyConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Produto> Produto = new List<Produto>() ;
            
            while(reader.Read()){
                Produto P = new Produto( reader["Nome"].ToString(), float.Parse(reader["Preco_venda"].ToString()), float.Parse(reader["Custo"].ToString()));
                P.Id = reader["Id"].ToString();
                Produto.Add(P);
                   
            }
            
                reader.Close();
                cmd.ExecuteNonQuery();
                C.Fechar();
                return Produto;

        }
        public void AtualizarProduto(string id, string nome, float preco, float custo ){
            Conexao C = new Conexao();
            SqlCommand cmd = new SqlCommand("UPDATE Produto set nome=@nome, Preco_venda=@preco, custo=@custo where id=CONVERT(VARCHAR, @id)", C.MyConnection);
        
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Text, 10);
            SqlParameter nomeParam = new SqlParameter("@nome", SqlDbType.Text, 100);
            SqlParameter precoParam = new SqlParameter("@preco", SqlDbType.Float);
            SqlParameter custoParam = new SqlParameter("@custo", SqlDbType.Float);
            idParam.Value = id;
            nomeParam.Value = nome;
            precoParam.Value = preco;
            custoParam.Value = custo;
            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(nomeParam);
            cmd.Parameters.Add(precoParam);
            cmd.Parameters.Add(custoParam);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            C.Fechar();
        }
        public void ExcluirProduto(string id){
            
            Conexao C = new Conexao();
            SqlCommand cmd = new SqlCommand("DELETE from Produto WHERE id=Convert(varchar, @id)", C.MyConnection);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Text, 10);
            idParam.Value = id;
            cmd.Parameters.Add(idParam);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            C.Fechar();

        }
    }
}
