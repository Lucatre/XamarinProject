using Base.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base.PUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarPerfil : ContentPage
    {
        Usuario usuarioActual;
        public ModificarPerfil(Usuario usuario)
        {
            this.usuarioActual = usuario;
            InitializeComponent();
            txtEmail.Text = usuario.Email;
            txtNombre.Text = usuario.Nombre;
            txtPApellido.Text = usuario.PrimerApellido;
            txtSApellido.Text = usuario.SegundoApellido;
            txtCelular.Text = usuario.Celular;
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtCPassword.Text) || String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtPApellido.Text) || String.IsNullOrEmpty(txtSApellido.Text) || String.IsNullOrEmpty(txtCelular.Text))
            {
                DisplayAlert("Error", "Favor complete todos los campos", "Ok");
            }
            else
            {
                if (txtPassword.Text.Equals(txtCPassword.Text))
                {
                    usuarioActual.Password = txtPassword.Text;
                    usuarioActual.Nombre = txtNombre.Text;
                    usuarioActual.PrimerApellido = txtPApellido.Text;
                    usuarioActual.SegundoApellido = txtSApellido.Text;
                    usuarioActual.Celular = txtCelular.Text;
                    DataAccess.Instancia.UpdateUsuario(usuarioActual);
                    DisplayAlert("Información", "Su Perfil ha sido actualizado", "Ok");
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