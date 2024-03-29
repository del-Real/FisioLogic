﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioLogicV2.Classes
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string Direccion { set; get; }
        public string Ciudad { set; get; }
        public int Telefono { set; get; }
        public int Edad { set; get; }
        public string Genero { set; get; }
        public Uri Foto { set; get; }
        public string Email { set; get; }

        public Paciente(int id, string nombre, string apellidos, string direccion, string ciudad, int telefono, int edad, string genero, Uri foto, string email)
        {
            IdPaciente = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Ciudad = ciudad;
            Telefono = telefono;
            Edad = edad;
            Genero = genero;
            Foto = foto;
            Email = email;
        }

        public Paciente(int id, string nombre, string apellidos, string direccion, string ciudad, int telefono, int edad, string genero, string email)
        {
            string rutaFoto = "FisioLogic\\m_user.png";
            Uri uriImagen = new Uri(rutaFoto, UriKind.RelativeOrAbsolute);
            IdPaciente = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Ciudad = ciudad;
            Telefono = telefono;
            Edad = edad;
            Genero = genero;
            Foto = uriImagen;
            Email = email;
        }

    }
}

