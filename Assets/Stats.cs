using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stats : VisualElement
{
    public new class UxmlFactory : UxmlFactory<Stats, UxmlTraits> { };

    List<VisualElement> list = new List<VisualElement>();
    Texture2D texture = Resources.Load<Texture2D>("Images/menuCreate/Espada");
    public Stats()
    {
        VisualElement espada1 = new VisualElement();
        VisualElement espada2 = new VisualElement();
        VisualElement espada3 = new VisualElement();
        VisualElement espada4 = new VisualElement();
        VisualElement espada5 = new VisualElement();

        espada1.style.width = 100;
        espada1.style.backgroundImage = texture;
        espada1.style.height = 100;
        espada2.style.width = 100;
        espada2.style.backgroundImage = texture;
        espada2.style.height = 100;
        espada3.style.width = 100;
        espada3.style.backgroundImage = texture;
        espada3.style.height = 100;
        espada4.style.width = 100;
        espada4.style.backgroundImage = texture;
        espada4.style.height = 100;
        espada5.style.width = 100;
        espada5.style.height = 100;
        espada5.style.backgroundImage = texture;

        //styleSheets.Add(Resources.Load<StyleSheet>("Lab4"));
        list.Add(espada1);
        list.Add(espada2);
        list.Add(espada3);
        list.Add(espada4);
        list.Add(espada5);
        espada1.AddToClassList("escudos");
        espada2.AddToClassList("escudos");
        espada3.AddToClassList("escudos");
        espada4.AddToClassList("escudos");
        espada5.AddToClassList("escudos");
        hierarchy.Add(espada1);
        hierarchy.Add(espada2);
        hierarchy.Add(espada3);
        hierarchy.Add(espada4);
        hierarchy.Add(espada5);
    }
    int nivelEspada;
    public int NivelEspada
    {
        get => nivelEspada;
        set
        {
            nivelEspada = value;
            sumarUnEspada();
        }
    }
    void sumarUnEspada()
    {
        for (int i = nivelEspada; i < 5; i++)
        {
            list[i].style.unityBackgroundImageTintColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.backgroundColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderLeftColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderRightColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderTopColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderBottomColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            
        }
        for (int i = 0; i < nivelEspada; i++)
        {
            list[i].style.unityBackgroundImageTintColor = new Color(99.0f, 99.0f, 99.0f, 255f);
            list[i].style.backgroundColor = new Color(99.0f, 99.0f, 99.0f, 255.0f);
            list[i].style.borderLeftColor = new Color(99.0f, 99.0f, 99.0f, 255f);
            list[i].style.borderRightColor = new Color(99.0f, 99.0f, 99.0f, 255f);
            list[i].style.borderTopColor = new Color(99.0f, 99.0f, 99.0f, 255f);
            list[i].style.borderBottomColor = new Color(99.0f, 99.0f, 99.0f, 255f);
        }

    }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myEspada = new UxmlIntAttributeDescription { name = "espada", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var numEscudo = ve as Stats;
            numEscudo.NivelEspada = myEspada.GetValueFromBag(bag, cc);
        }

    }
}

