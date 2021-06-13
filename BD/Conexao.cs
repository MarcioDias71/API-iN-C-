using System;
using System.Data;
using System.Data.SqlClient;

namespace BD {
    public class Conexao{

        public Conexao(){
            this.connectionString =  "Server=localhost;Database=Produto;User Id=SA;Password=adm012Bash@;MultipleActiveResultSets=True";
            this.MyConnection = new SqlConnection(this.connectionString);
            this.Abrir();
        }
        
         public string connectionString { get; set; }
         public SqlConnection MyConnection { get; set; }

        public void Abrir(){
           
          try
             {
        

                  this.MyConnection.Open();

             }
          catch (SqlException ex)
            {
           
                 Console.WriteLine("erro: "+ex);
             }

       }
        public void Fechar(){
        
                 this.MyConnection.Close();

        }  
    }
}
     