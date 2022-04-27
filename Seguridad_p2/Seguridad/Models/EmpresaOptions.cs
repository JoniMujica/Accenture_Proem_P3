namespace Seguridad.Models
{
    public class EmpresaOptions
    {
        //creo una intencia de appsettings.json
        public const string Seccion = "Empresa";
        public string RazonSocial { get; set; } = String.Empty; //estos campos deben respetas espacios,minusculas y mayusuclas del appsettings
        public string Cuit { get; set; } = String.Empty;
    }
}
