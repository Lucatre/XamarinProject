using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Base
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnIngresar.Clicked += BtnIngresar_Clicked;
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if ((txt_email.Text == "admin") && (txt_pass.Text == "123"))
            {
                ((NavigationPage)this.Parent).PushAsync(new Home(txt_email.Text));
            }
            else
            {
                MostrarAlertaButtonClicked(sender, e);
            }
        }

        async void MostrarAlertaButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alerta", "Credenciales incorrectas", "Aceptar");
        }
    }
}
