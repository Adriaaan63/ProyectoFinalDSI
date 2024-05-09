using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

namespace Lab5c_namespace
{
    public class Tarjeta
    {
        Individuo miIndividuo;

        VisualElement tarjetaRoot;

        Label nombreLabel;

        public Tarjeta(VisualElement tarjetaroot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaroot;
            this.miIndividuo = individuo;

            nombreLabel = tarjetaRoot.Q<Label>("Nombre");
            tarjetaRoot.userData = individuo;

            tarjetaRoot.Query(className: "tarjeta").Descendents<VisualElement>().ForEach(elem => elem.pickingMode = PickingMode.Ignore); ;

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI ()
        {
            nombreLabel.text = miIndividuo.Nombre;
        }
    }
}
