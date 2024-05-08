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
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        attackStats = root.Q<TextField>("AttackText");
        attack = root.Q<Stats>("Stats");
        defenseStats = root.Q<TextField>("DefenseText");
        defense = root.Q<Stats1>("Stats1");
        attackStats.RegisterCallback<ChangeEvent<string>>(ChangeAttack);
        defenseStats.RegisterCallback<ChangeEvent<string>>(ChangeDefense);

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
}
