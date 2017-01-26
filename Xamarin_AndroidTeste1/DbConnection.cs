using System;
using System.Data.SqlClient;

public class DbConnection
{

    String StringCon;


    public DbConnection(String StringCS)
	{

        StringCon = StringCS;
     
    }

    //Executa o comando SQL passado como parametro 
    public void Execute(String StringCmd)
    {
        using (SqlConnection connection = new SqlConnection(StringCon))
        {
            connection.Open();
            // Do work here; connection closed on following line.
            SqlCommand cmd = new SqlCommand(StringCmd);
            cmd.Connection = connection;
            cmd.ExecuteNonQuery( );

        }


    }

    //Passando um comando SQL, retorna um valor 
    public object QueryValue(String StringCmd)
    {
        using (SqlConnection connection = new SqlConnection(StringCon))
        {
            connection.Open();
            // Do work here; connection closed on following line.
            SqlCommand cmd = new SqlCommand(StringCmd);
            cmd.Connection = connection;

            return cmd.ExecuteScalar();

        }


    }

    //Passando um comando SQL, retorna um conjunto de dados 
    public SqlDataReader QueryData(String StringCmd)
    {
        using (SqlConnection connection = new SqlConnection(StringCon))
        {
            connection.Open();
            // Do work here; connection closed on following line.
            SqlCommand cmd = new SqlCommand(StringCmd);
            cmd.Connection = connection;

            return cmd.ExecuteReader();

        }


    }

}
