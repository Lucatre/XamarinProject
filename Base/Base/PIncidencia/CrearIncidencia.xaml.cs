using Base.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base.PIncidencia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearIncidencia : ContentPage
    {
        Usuario usuarioActual;
        public CrearIncidencia(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            CargarTipoIncidencia();
        }

        private async void btnCancelars_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnCrear_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text) || String.IsNullOrEmpty(txtUbicacion.Text) || String.IsNullOrEmpty(txtContacto.Text) || pTipoIncidencia.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Favor ingrese todos los datos solicitados", "Cerrar");
            }
            else
            {
                var i = new Incidencia
                {
                    Contacto = txtContacto.Text,
                    Descripcion = txtDescripcion.Text,
                    Estado = "Creada",
                    FechaCreacion = DateTime.Now,
                    Ubicacion = txtUbicacion.Text,
                    Usuario = usuarioActual.NombreCompleto,
                    UsuarioID = usuarioActual.UsuarioID
                };
                if (pTipoIncidencia.SelectedIndex == 0)
                {
                    i.TipoIncidencia = "Averia Internet";
                }
                if (pTipoIncidencia.SelectedIndex == 1)
                {
                    i.TipoIncidencia = "Averia Telefonica";
                }
                if (pTipoIncidencia.SelectedIndex == 2)
                {
                    i.TipoIncidencia = "Nuevos Servicios";
                }
                var resultado = DataAccess.Instancia.InsertIncidencia(i);
                DisplayAlert("Informacion", resultado, "Ok");
                ((NavigationPage)this.Parent).PopAsync();

            }
        }

        private void CargarTipoIncidencia()
        {
            pTipoIncidencia.Items.Add("Averia Internet");
            pTipoIncidencia.Items.Add("Averia Telefonica");
            pTipoIncidencia.Items.Add("Nuevos Servicios");

        }
    }
}