using System;
using System.Data.SqlClient;

public class DbConnection
{
	public DbConnection()
	{

        System.Data.SqlClient.SqlConnectionStringBuilder csBuilder =
        new System.Data.SqlClient.SqlConnectionStringBuilder();
        csBuilder["Data Source"] = "(local)";
        csBuilder["integrated Security"] = true;
        csBuilder["Initial Catalog"] = "SIGED";

        using (SqlConnection connection = new SqlConnection(csBuilder.connectionString))
        {
            connection.Open();
            // Do work here; connection closed on following line.
            SqlCommand cmd = new SqlCommand("Insert into BGNDNT(DNT_NUM,DNT_NOME) Values('1600001','Rui Silva')");
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

        }

    }
}
