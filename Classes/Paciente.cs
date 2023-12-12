using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Paciente
{
    public int IdPaciente { get; set; }
    public string Nombre { set; get; }
    public string Apellidos { set; get; }
    public string Direccion { set; get; }
    public int Telefono { set; get; }
    public int Edad { set; get; }
    public string Genero { set; get; }
    public Uri Foto { set; get; }
    public string Email { set; get; }

    public Paciente(int id, string nombre, string apellidos, string direccion, int telefono, int edad, string genero, Uri foto, string email)
    {
        IdPaciente = id;
        Nombre = nombre;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefono = telefono;
        Edad = edad;
        Genero = genero;
        Foto = foto;
        Email = email;
    }
}


