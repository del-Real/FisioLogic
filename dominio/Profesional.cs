using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Profesional
{
    public int IdProfesional { get; set; }
    public string Nombre { set; get; }
    public string Apellidos { set; get; }
    public int Edad { set; get; }
    public Uri Foto { set; get; }
    public int Telefono { set; get; }

    public List<int> Fechas = new List<int>();

     public Profesional(int id, string nombre, string apellidos, int edad, Uri foto, int telefono)
    {
        IdProfesional = id;
        Nombre = nombre;
        Apellidos = apellidos;
        Edad = edad;
        Foto = foto;
        Telefono = telefono;
    }
}
