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
    public partial class ModificarUsuario : ContentPage
    {
        Usuario usuarioActual;
        public ModificarUsuario(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            CargarTipoUsuario();
            txtEmail.Text = usuario.Email;
            txtPassword.Text = usuario.Password;
            txtCPassword.Text = usuario.Password;
            txtNombre.Text = usuario.Nombre;
            txtPApellido.Text = usuario.PrimerApellido;
            txtSApellido.Text = usuario.SegundoApellido;
            txtCelular.Text = usuario.Celular;
            sActivo.IsToggled = usuario.Activo;
            if (usuario.TipoUsuario=="A")
            {
                pTipoUsuario.SelectedIndex = 0;
            }
            if (usuario.TipoUsuario == "C")
            {
                pTipoUsuario.SelectedIndex = 1;
            }

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
                    usuarioActual.Activo = sActivo.IsToggled;
                    if (pTipoUsuario.SelectedIndex == 0)
                    {
                        usuarioActual.TipoUsuario = "A";
                    }
                    if (pTipoUsuario.SelectedIndex == 1)
                    {
                        usuarioActual.TipoUsuario = "C";
                    }
                    DataAccess.Instancia.UpdateUsuario(usuarioActual);
                    DisplayAlert("Información", "Usuario actualizado correctamente", "Ok");
                    ((NavigationPage)this.Parent).PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "El password y la confirmacion son diferentes", "Ok");
                }
            }
        }

        public void CargarTipoUsuario()
        {
            pTipoUsuario.Items.Add("Administrador");
            pTipoUsuario.Items.Add("Cliente");
        }
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var respuesta = await DisplayAlert("Confirmacion", "¿Esta seguro que desea eliminar al usuario " + usuarioActual.Email + "?", "Si", "No");
            if (!respuesta)
            {
                return;
            }
            else
            {
                DataAccess.Instancia.DeleteUsuario(usuarioActual);
                await DisplayAlert("Confirmacion", "Usuario eliminado exitosamente", "Ok");
                await Navigation.PopAsync();
            }
            
        }
    }
}