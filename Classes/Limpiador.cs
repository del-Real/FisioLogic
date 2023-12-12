using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Limpiador : Profesional
{
    public string AreaAsignada { set; get; }

    public Limpiador(int id, string nombre, string apellidos, int edad, Uri foto, int telefono, string areaAsignada)
        : base(id, nombre, apellidos, edad, foto, telefono)
    {
        AreaAsignada = areaAsignada;
    }
}
