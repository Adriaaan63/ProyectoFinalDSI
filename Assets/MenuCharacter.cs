using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuCharacter : MonoBehaviour
{
    TextField attackStats;
    Stats attack;
    TextField defenseStats;
    Stats1 defense;
    TextField input_name;
    Label nameLabel;

    VisualElement imagePrin;
    VisualElement skin1, skin2, skin3, skin4;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        attackStats = root.Q<TextField>("AttackText");
        attack = root.Q<Stats>("Stats");
        defenseStats = root.Q<TextField>("DefenseText");
        defense = root.Q<Stats1>("Stats1");
        input_name = root.Q<TextField>("NameText");
        nameLabel = root.Q<Label>("Nombre");

        imagePrin = root.Q<VisualElement>("skin");
        skin1 = root.Q<VisualElement>("P1");
        skin2 = root.Q<VisualElement>("P2");
        skin3 = root.Q<VisualElement>("P3");
        skin4 = root.Q<VisualElement>("P4");

        attackStats.RegisterCallback<ChangeEvent<string>>(ChangeAttack);
        defenseStats.RegisterCallback<ChangeEvent<string>>(ChangeDefense);
        input_name.RegisterCallback<ChangeEvent<string>>(ChangeName);
        skin1.RegisterCallback<ClickEvent>(ChangeImage);
        skin2.RegisterCallback<ClickEvent>(ChangeImage);
        skin3.RegisterCallback<ClickEvent>(ChangeImage);
        skin4.RegisterCallback<ClickEvent>(ChangeImage);
    }
    void ChangeAttack(ChangeEvent<string> e)
    {
        int newAttackValue;
        if (int.TryParse(e.newValue, out newAttackValue) && newAttackValue <= 5) // Intenta convertir el nuevo valor a int
        {

            Debug.Log(e.newValue);
            // Actualiza el valor de myEspada en la instancia de Stats
            attack.NivelEspada = newAttackValue;
        }

    }
    void ChangeDefense(ChangeEvent<string> e)
    {
        int newDefenseValue;
        if (int.TryParse(e.newValue, out newDefenseValue) && newDefenseValue <= 5) // Intenta convertir el nuevo valor a int
        {

            Debug.Log(e.newValue);
            // Actualiza el valor de myEspada en la instancia de Stats
            defense.NivelEscudo = newDefenseValue;
        }

    }
    void ChangeName(ChangeEvent<string> e)
    {
        if(e.newValue.Length < 10)
            nameLabel.text = e.newValue;
    }
    void ChangeImage(ClickEvent e)
    {
            VisualElement skins = e.target as VisualElement;
        Sprite per = null;
        if (skins == skin1)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character1");
        }
        else if(skins == skin2)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character2");
        }
        else if(skins == skin3)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character3");
        }
        else if (skins == skin4)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character4");
        }
            imagePrin.style.backgroundImage = new StyleBackground(per);
    }
}
