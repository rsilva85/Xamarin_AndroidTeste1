using Android.App;
using Android.Widget;
using Android.OS;
using System.Data.SqlClient;
using System;
using Android.Content;

namespace Xamarin_AndroidTeste1
{
    [Activity(Label = "Xamarin AndroidTeste1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DbConnection dbCon;
        TextView textView_Label1;
        TextView textView_pesqNomeUtente;
        EditText editText_codUtente;
        EditText editText_nomeUtente;
        EditText editText_pesqCodUtente;
        Button buttonInserir;
        Button buttonPesquisar;
        Button buttonOutra;

        protected override void OnCreate(Bundle bundle)
        {
            //Base commands
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            //////////////

            dbCon = new DbConnection("Persist Security Info=False;Integrated Security=false;Initial Catalog=SIGED;Data Source=7.122.25.140,49172;User=sqlremote;Password=sisbit.");

            textView_Label1 = FindViewById<TextView>(Resource.Id.textView_Label1);
            textView_pesqNomeUtente = FindViewById<TextView>(Resource.Id.textView_pesqNomeUtente);

            editText_codUtente = FindViewById<EditText>(Resource.Id.editText_codUtente);
            editText_nomeUtente = FindViewById<EditText>(Resource.Id.editText_nomeUtente);
            editText_pesqCodUtente = FindViewById<EditText>(Resource.Id.editText_pesqCodUtente);

            buttonInserir = FindViewById<Button>(Resource.Id.buttonInserir);
            buttonPesquisar = FindViewById<Button>(Resource.Id.buttonPesquisar);
            buttonOutra = FindViewById<Button>(Resource.Id.buttonOutra);

            buttonInserir.Click += Inserir_OnClick;
            buttonPesquisar.Click += Pesquisar_OnClick;
            buttonOutra.Click += ButtonOutra_Click;



        }

        private void ButtonOutra_Click(object sender, EventArgs e)
        {

            var OutraIntent = new Intent(this, typeof(OutraActivity));
            StartActivity(OutraIntent);



        }

        void Inserir_OnClick(object Sender, EventArgs e)
        {

            String codigo, nome;
            codigo = editText_codUtente.Text;
            nome = editText_nomeUtente.Text;

            dbCon.Execute("Insert into BGNDNT(DNT_NUM,DNT_NOME) Values('"+codigo+"','"+nome+"')");

            textView_Label1.Text = "Utente inserido.";

        }

        void Pesquisar_OnClick(object Sender, EventArgs e)
        {

            String codigo;
            codigo = editText_pesqCodUtente.Text;

            textView_pesqNomeUtente.Text = (String) dbCon.QueryValue("Select DNT_NOME from BGNDNT where DNT_NUM='" + codigo + "'");

            

        }

    }
}

