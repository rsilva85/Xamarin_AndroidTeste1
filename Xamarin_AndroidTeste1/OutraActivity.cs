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
            using (SqlConnection connection = new SqlConnection("Persist Security Info=False;Integrated Security=false;Initial Catalog=SIGED;Data Source=192.168.1.69;User=sa;Password=sqlsa"))
            {
                connection.Open();
                // Do work here; connection closed on following line.
                SqlCommand cmd = new SqlCommand("Select DNT_NUM,DNT_NOME from BGNDNT");
                cmd.Connection = connection;

                dr= cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new String[] {
                        dr["DNT_NUM"].ToString()
                        , dr["DNT_NOME"].ToString()
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
        }
    }
}