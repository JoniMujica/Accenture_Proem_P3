using E1WPF.Models;
using E1WPF.Services;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E1WPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nombre;
        private decimal precio;

        public int Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Nombre { get => nombre; set { nombre = value; OnPropertyChanged("Nombre"); } }
        public decimal Precio { get => precio; set { precio = value; OnPropertyChanged("Precio"); } }
        private readonly IArticulosService servicio;
        public ICommand Guardar { get; set; }

        public MainViewModel()
        {
            Guardar = new DelegateCommand((x)=>OnGuardar());
            servicio = RestService.For<IArticulosService>("https://localhost:7051");
        }
        private async void OnGuardar()
        {
            /*HttpClient client = new();
            var response = await client.GetStringAsync("https://localhost:7051/api/Articulos");
            var result = JsonConvert.DeserializeObject<List<Articulo>>(response);

            var servicio = RestService.For<IArticulosService>("https://localhost:7051");
            var Listado = await servicio.ObtenerArticulos();

            */
            await servicio.Insertar(new Articulo { Id = 0, Nombre = nombre, Precio = precio });
            var listado = await servicio.ObtenerArticulos();

            Id = 0;
            Nombre = "";
            Precio = 0;
            //OnPropertyChanged("Nombre");
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
