using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioLogicV2.Classes
{
    internal class Historial
    {
        public int idHistorial {  get; set; }
        public int Dia { set; get; }
        public string Hora { set; get; }
        public int Mes { set; get; }
        public int Year { set; get; }
        public string fecha { set; get; }
        public string paciente { set; get; }
        public int telefono { set; get; }
        public string especialidad { set; get; }
        public string profesional { set; get;}

        public Historial(int idHistorial, int dia, int mes, int year, string hora, string paciente, int telefono, string especialidad, string profesional)
        {
            this.idHistorial = idHistorial;
            Dia = dia;
            Hora = hora;
            Mes = mes;
            Year = year;
            fecha = dia+"/"+mes+"/"+year;
            this.paciente = paciente;
            this.telefono = telefono;
            this.especialidad = especialidad;
            this.profesional = profesional;
        }
    }
}
