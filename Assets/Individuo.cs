using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace Lab5c_namespace
{
    public class Individuo
    {
        public event Action Cambio;

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    Cambio?.Invoke(); 
                }
            }
        }
        private VisualElement imagen;

        public VisualElement Imagen
        {
            get { return imagen; }
            set
            {
                if (imagen != value)
                {
                    imagen = value;
                    Cambio?.Invoke();
                }
            }
        }

        public Individuo(string nombre, VisualElement image)
        {

            this.nombre = nombre;
            this.imagen = image;

        }
    }
}
