using FisioLogicV2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sanitario : Profesional
{
    public string Especialidad { set; get; }

    public List<Paciente> Pacientes { get; } = new List<Paciente>();
    public List<Cita> Citas { get; } = new List<Cita>();

    public Sanitario(int id, string nombre, string apellidos, int edad, Uri foto, int telefono, string especialidad)
        : base(id, nombre, apellidos, edad, foto, telefono)
    {
        Especialidad = especialidad;
    }

    public Sanitario(int id, string nombre, string apellidos, int edad, int telefono, string especialidad)
        : base(id, nombre, apellidos, edad, telefono)
    {
        Especialidad = especialidad;
    }
}
