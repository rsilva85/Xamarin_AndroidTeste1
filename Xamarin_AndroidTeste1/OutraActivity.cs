using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Data.SqlClient;
using System.Collections;

namespace Xamarin_AndroidTeste1
{
    [Activity(Label = "OutraActivity")]
    public class OutraActivity : Activity
    {

        //DbConnection dbCon;
        GridView gvTeste;
        ArrayList lista;

        ArrayAdapter adapt;
        SqlDataReader dr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Outra);
            // Create your application here

            //dbCon = new DbConnection("Persist Security Info=False;Integrated Security=false;Initial Catalog=SIGED;Data Source=192.168.1.69;User=sa;Password=sqlsa");
            gvTeste = FindViewById<GridView>(Resource.Id.gridView_teste);

            //dr = dbCon.QueryData("Select DNT_NUM,DNT_NOME from BGNDNT");
            lista = new ArrayList();
            using (SqlConnection connection = new SqlConnection("Persist Security Info=False;Integrated Security=false;Initial Catalog=SIGED;Data Source=192.168.1.69;User=sa;Password=sqlsa"))
            {
                connection.Open();
                // Do work here; connection closed on following line.
                SqlCommand cmd = new SqlCommand("Select DNT_NUM,DNT_NOME from BGNDNT");
                cmd.Connection = connection;

                dr= cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(dr["DNT_NOME"].ToString());
                    
                }

            }


            adapt = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, lista);
            gvTeste.Adapter = adapt;
        }
    }
}