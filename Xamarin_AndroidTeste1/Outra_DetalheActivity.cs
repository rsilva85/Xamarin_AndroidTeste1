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

namespace Xamarin_AndroidTeste1
{
    [Activity(Label = "Outra Detalhe")]
    public class Outra_DetalheActivity : Activity
    {

        TextView tv_getnUtente;
        TextView tv_getNomeUtente;
        TextView tv_getDtNasc;
        TextView tv_getMorada;
        TextView tv_getCodPostal;
        TextView tv_getEntidade;
        TextView tv_getBenef;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Outra_Detalhe);

         
            tv_getnUtente = FindViewById<TextView>(Resource.Id.textView_getnUtente);
            tv_getNomeUtente = FindViewById<TextView>(Resource.Id.textView_getNomeUtente);
            tv_getDtNasc = FindViewById<TextView>(Resource.Id.textView_getDtNasc);
            tv_getMorada = FindViewById<TextView>(Resource.Id.textView_getMorada);
            tv_getCodPostal = FindViewById<TextView>(Resource.Id.textView_getCodPostal);
            tv_getEntidade = FindViewById<TextView>(Resource.Id.textView_getEntidade);
            tv_getBenef = FindViewById<TextView>(Resource.Id.textView_getBenef);
            
            // Create your application here

            tv_getnUtente.Text = Intent.GetStringExtra("DNT_NUM");
            tv_getNomeUtente.Text = Intent.GetStringExtra("DNT_NOME");
            tv_getDtNasc.Text = Intent.GetStringExtra("DNT_DATNAS");
            tv_getMorada.Text = Intent.GetStringExtra("DNT_MORADA");
            tv_getCodPostal.Text = Intent.GetStringExtra("DNT_POSTAL");
            tv_getEntidade.Text = Intent.GetStringExtra("DNT_SUBS");
            tv_getBenef.Text = Intent.GetStringExtra("NUM_BEN");
            


        }
    }
}