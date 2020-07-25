using Base.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearUsuario : ContentPage
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void btnCrear_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text)|| String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtCPassword.Text) || String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtPApellido.Text) || String.IsNullOrEmpty(txtSApellido.Text) || String.IsNullOrEmpty(txtCelular.Text))
            {
                DisplayAlert("Error", "Favor complete todos los campos", "Ok");
            }
            else
            {
                if (txtPassword.Text.Equals(txtCPassword.Text))
                {
                    var usuario = new Usuario
                    {
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        Nombre = txtNombre.Text,
                        PrimerApellido = txtPApellido.Text,
                        SegundoApellido = txtSApellido.Text,
                        Celular = txtCelular.Text,
                        TipoUsuario = "C",
                        Activo = true
                    };
                    string respuesta = DataAccess.Instancia.InsertUsuario(usuario);
                    DisplayAlert("Información", respuesta, "Ok");
                    ((NavigationPage)this.Parent).PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "El password y la confirmacion son diferentes", "Ok");
                }
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}