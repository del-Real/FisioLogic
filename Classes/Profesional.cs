using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Profesional
{
    public int IdProfesional { get; set; }
    public string Nombre { set; get; }
    public string Apellidos { set; get; }
    public string nombrecompleto { set; get; }
    public int Edad { set; get; }
    public Uri Foto { set; get; }
    public int Telefono { set; get; }

    public List<int> Fechas = new List<int>();
    private int id;

    public Profesional(int id, string nombre, string apellidos, int edad, Uri foto, int telefono)
    {
        IdProfesional = id;
        Nombre = nombre;
        Apellidos = apellidos;
        nombrecompleto = nombre + " " + apellidos;
        Edad = edad;
        Foto = foto;
        Telefono = telefono;
    }

    public Profesional(int id, string nombre, string apellidos, int edad, int telefono)
    {
        string rutaFoto = "FisioLogic\\m_user.png";
        Uri uriImagen = new Uri(rutaFoto, UriKind.RelativeOrAbsolute);
        this.id = id;
        Nombre = nombre;
        Apellidos = apellidos;
        nombrecompleto = nombre + " " + apellidos;
        Edad = edad;
        Foto = uriImagen;
        Telefono = telefono;
    }
}
