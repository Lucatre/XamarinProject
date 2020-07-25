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
    public partial class ModificarIncidencia : ContentPage
    {
        Incidencia incidenciaActual;
        public ModificarIncidencia(Incidencia incidencia)
        {
            incidenciaActual = incidencia;
            InitializeComponent();
            CargarPickers();
            txtIncidenciaID.Text = incidencia.IncidenciaID.ToString();
            txtDescripcion.Text = incidencia.Descripcion;
            pTipoIncidencia.SelectedIndex = TipoIncidenciaIndex(incidencia.TipoIncidencia);
            pEstado.SelectedIndex = EstadoIndex(incidencia.Estado);
            txtCreacion.Text = incidencia.FechaCreacion.ToString();
            txtUsuario.Text = incidencia.Usuario;
            txtUbicacion.Text = incidencia.Ubicacion;
            txtContacto.Text = incidencia.Contacto;
            fFinalizacion.MinimumDate = incidencia.FechaCreacion;
        }


        private void CargarPickers()
        {
            pTipoIncidencia.Items.Add("Averia Internet");
            pTipoIncidencia.Items.Add("Averia Telefonica");
            pTipoIncidencia.Items.Add("Nuevos Servicios");
            pEstado.Items.Add("Creada");
            pEstado.Items.Add("Asignada");
            pEstado.Items.Add("Proceso");
            pEstado.Items.Add("Resuelta");
        }

        private string TipoIncidenciaValue(int index)
        {
            switch (index)
            {
                case 0:
                    return "Averia Internet";
                case 1:
                    return "Averia Telefonica";
                case 2:
                    return "Nuevos Servicios";
                default:
                    return "Error";
            }
        }

        private int TipoIncidenciaIndex(string tipo)
        {
            if (tipo=="Averia Internet")
            {
                return 0;
            }
            if (tipo == "Averia Telefonica")
            {
                return 1;
            }
            if (tipo == "Nuevos Servicios")
            {
                return 2;
            }
            return -1;
        }

        private string EstadoValue(int index)
        {
            switch (index)
            {
                case 0:
                    return "Creada";
                case 1:
                    return "Asignada";
                case 2:
                    return "Proceso";
                case 3:
                    return "Resuelta";
                default:
                    return "Error";
                    
            }
        }

        private int EstadoIndex(string estado)
        {
            if (estado == "Creada")
            {
                return 0;
            }
            if (estado == "Asignada")
            {
                return 1;
            }
            if (estado == "Proceso")
            {
                return 2;
            }
            if (estado == "Resuelta")
            {
                return 3;
            }
            return -1;
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text)|| String.IsNullOrEmpty(txtUbicacion.Text) || String.IsNullOrEmpty(txtContacto.Text))
            {
                DisplayAlert("Error", "No puede dejar campos en blanco", "Ok");
            }
            else
            {
                incidenciaActual.Descripcion = txtDescripcion.Text;
                incidenciaActual.TipoIncidencia = TipoIncidenciaValue(pTipoIncidencia.SelectedIndex);
                incidenciaActual.Estado = EstadoValue(pEstado.SelectedIndex);
                incidenciaActual.FechaFinalizacion = fFinalizacion.Date;
                incidenciaActual.Ubicacion = txtUbicacion.Text;
                incidenciaActual.Contacto = txtContacto.Text;
                DataAccess.Instancia.UpdateIncidencia(incidenciaActual);
                DisplayAlert("Información", "Incidencia actualizada exitosamente", "Ok");
                ((NavigationPage)this.Parent).PopAsync();
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var respuesta = await DisplayAlert("Confirmacion", "¿Desea eliminar la incidencia código " + incidenciaActual.IncidenciaID + "?", "Si", "No");
            if (!respuesta)
            {
                return;
            }
            else
            {
                DataAccess.Instancia.DeleteIncidencia(incidenciaActual);
                await DisplayAlert("Confirmacion", "Incidencia eliminada exitosamente", "Ok");
                await Navigation.PopAsync();
            }
        }
    }


    
}