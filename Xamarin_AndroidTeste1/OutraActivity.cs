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
    [Activity(Label = "Outra Activity")]
    public class OutraActivity : Activity
    {

        //DbConnection dbCon;
        ListView lvTeste;
        List<string[]> lista;

        
        SqlDataReader dr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Outra);
            // Create your application here

            //dbCon = new DbConnection("Persist Security Info=False;Integrated Security=false;Initial Catalog=SIGED;Data Source=192.168.1.69;User=sa;Password=sqlsa");
            lvTeste = FindViewById<ListView>(Resource.Id.listView);

            //dr = dbCon.QueryData("Select DNT_NUM,DNT_NOME from BGNDNT");
            lista = new List<string[]>();
            using (SqlConnection connection = new SqlConnection(MainActivity.cConn)) 
            {
                connection.Open();
                // Do work here; connection closed on following line.
                SqlCommand cmd = new SqlCommand("Select top 10 DNT_NUM,DNT_NOME,DNT_DATNAS, DNT_MORADA, DNT_POSTAL, DNT_SUBS, NUM_BEN from BGNDNT ");
                cmd.Connection = connection;

                dr= cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new String[] {
                        dr["DNT_NUM"].ToString()
                        , dr["DNT_NOME"].ToString()
                        , dr["DNT_DATNAS"].ToString()
                        , dr["DNT_MORADA"].ToString()
                        , dr["DNT_POSTAL"].ToString()
                        , dr["DNT_SUBS"].ToString()
                        , dr["NUM_BEN"].ToString()
                    });
                    
                }

            }

            lvTeste.Adapter = new TableAdapter(this, lista);
            lvTeste.ItemClick += LvTeste_ItemClick;
              
        }

        private void LvTeste_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = lista[e.Position];
            Android.Widget.Toast.MakeText(this, t[1], Android.Widget.ToastLength.Short).Show();

            var Outra_DetalheIntent = new Intent(this, typeof(Outra_DetalheActivity));
            Outra_DetalheIntent.PutExtra("DNT_NUM", t[0]);
            Outra_DetalheIntent.PutExtra("DNT_NOME", t[1]);
            Outra_DetalheIntent.PutExtra("DNT_DATNAS", t[2]);
            Outra_DetalheIntent.PutExtra("DNT_MORADA", t[3]);
            Outra_DetalheIntent.PutExtra("DNT_POSTAL", t[4]);
            Outra_DetalheIntent.PutExtra("DNT_SUBS", t[5]);
            Outra_DetalheIntent.PutExtra("NUM_BEN", t[6]);
 
            StartActivity(Outra_DetalheIntent);

        }
    }
}