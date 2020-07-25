using Base.Modelos;
using Base.PMenu;
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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            CrearAdministrador();
        }

        private void CrearAdministrador()
        {
            var u = DataAccess.Instancia.GetUsuario(1);
            if (u==null)
            {
                var administrador = new Usuario
                {
                    Nombre = "John",
                    PrimerApellido = "Doe",
                    SegundoApellido = "Doe",
                    Celular = "99999999",
                    Email = "admin@admin.com",
                    Password = "12345",
                    Activo = true,
                    TipoUsuario = "A"
                };
                DataAccess.Instancia.InsertUsuario(administrador);
                DisplayAlert("Informacion", "Bienvenido por primera vez credenciales: admin@admin.com y password: 12345","Cerrar");
            }
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text)||String.IsNullOrEmpty(txtPassword.Text))
            {
                DisplayAlert("Error", "Favor digite sus credenciales", "Ok");
            }
            else
            {
                var usuarioActual = DataAccess.Instancia.Login(txtEmail.Text, txtPassword.Text);
                if (usuarioActual==null)
                {
                    DisplayAlert("Error", "Usuario o contraseña inválidos", "Ok");
                }
                else
                {
                    if (usuarioActual.TipoUsuario=="A")
                    {
                        ((NavigationPage)this.Parent).PushAsync(new MenuAdmin(usuarioActual));

                    }
                    else
                    {
                        ((NavigationPage)this.Parent).PushAsync(new MenuCliente(usuarioActual));
                    }
                }
            }

        }

        private async void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearUsuario());
        }
    }
}