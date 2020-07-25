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
    public partial class VerIncidencia : ContentPage
    {
        public VerIncidencia(Incidencia incidencia)
        {
            InitializeComponent();
            txtIncidenciaID.Text = incidencia.IncidenciaID.ToString();
            txtDescripcion.Text = incidencia.Descripcion;
            txtTipoIncidencia.Text = incidencia.TipoIncidencia;
            txtEstado.Text = incidencia.Estado;
            txtCreacion.Text = incidencia.FechaCreacion.ToString();
            txtUsuario.Text = incidencia.Usuario;
            txtUbicacion.Text = incidencia.Ubicacion;
            txtContacto.Text = incidencia.Contacto;
            txtFinalizacion.Text = incidencia.FechaFinalizacion.ToString();
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}