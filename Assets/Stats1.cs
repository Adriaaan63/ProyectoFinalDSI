using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stats1 : VisualElement
{
    public new class UxmlFactory : UxmlFactory<Stats1, UxmlTraits> { };

    List<VisualElement> list = new List<VisualElement>();
    Texture2D texture = Resources.Load<Texture2D>("Images/menuCreate/Escudo");
    public Stats1()
    {
        VisualElement Escudo1 = new VisualElement();
        VisualElement Escudo2 = new VisualElement();
        VisualElement Escudo3 = new VisualElement();
        VisualElement Escudo4 = new VisualElement();
        VisualElement Escudo5 = new VisualElement();

        Escudo1.style.width = 100;
        Escudo1.style.backgroundImage = texture;
        Escudo1.style.height = 100;
        Escudo2.style.width = 100;
        Escudo2.style.backgroundImage = texture;
        Escudo2.style.height = 100;
        Escudo3.style.width = 100;
        Escudo3.style.backgroundImage = texture;
        Escudo3.style.height = 100;
        Escudo4.style.width = 100;
        Escudo4.style.backgroundImage = texture;
        Escudo4.style.height = 100;
        Escudo5.style.width = 100;
        Escudo5.style.height = 100;
        Escudo5.style.backgroundImage = texture;

        //styleSheets.Add(Resources.Load<StyleSheet>("Lab4"));
        list.Add(Escudo1);
        list.Add(Escudo2);
        list.Add(Escudo3);
        list.Add(Escudo4);
        list.Add(Escudo5);
        Escudo1.AddToClassList("escudos");
        Escudo2.AddToClassList("escudos");
        Escudo3.AddToClassList("escudos");
        Escudo4.AddToClassList("escudos");
        Escudo5.AddToClassList("escudos");
        hierarchy.Add(Escudo1);
        hierarchy.Add(Escudo2);
        hierarchy.Add(Escudo3);
        hierarchy.Add(Escudo4);
        hierarchy.Add(Escudo5);
    }
    int nivelEscudo=0;
    public int NivelEscudo
    {
        get => nivelEscudo;
        set
        {
            nivelEscudo = value;
            sumarUnEscudo();
        }
    }
    void sumarUnEscudo()
    {
        for (int i = nivelEscudo; i < 5; i++)
        {
            list[i].style.unityBackgroundImageTintColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.backgroundColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderLeftColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderRightColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderTopColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            list[i].style.borderBottomColor = new Color(99.0f, 99.0f, 99.0f, 0.3f);
            
        }
        for (int i = 0; i < nivelEscudo; i++)
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
        UxmlIntAttributeDescription myEscudo = new UxmlIntAttributeDescription { name = "Escudo", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var numEscudo = ve as Stats1;
            numEscudo.NivelEscudo = myEscudo.GetValueFromBag(bag, cc);
        }

    }
}

