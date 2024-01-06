using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Cita
{
    public int IdCita { get; set; }
    public int Dia { set; get; }
    public string Hora { set; get; }
    public int Mes { set; get; }
    public int Year { set; get; }
    public string Paciente { set; get; }
    public string Profesional { set; get; }
    public int Duracion { set; get; }
    public string Informacion { set; get; }

    public Cita(int id, int dia, string hora, int mes, int year, string paciente, string profesional, int duracion, string informacion)
    {
        IdCita = id;
        Dia = dia;
        Hora = hora;
        Mes = mes;
        Year = year;
        Paciente = paciente;
        Profesional = profesional;
        Duracion = duracion;
        Informacion = informacion; 
    }
}

