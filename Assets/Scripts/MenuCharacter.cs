using System.Collections;
using System.Collections.Generic;
using Lab5c_namespace;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuCharacter : MonoBehaviour
{
    TextField attackStats;
    Stats attack;
    TextField defenseStats;
    Stats1 defense;
    TextField input_name;
    Label nameLabel;

    VisualElement skinPos;
    VisualElement imagePrin;
    VisualElement auxSkin;
    VisualElement skin1, skin2, skin3, skin4;

    VisualElement create;
    StyleBackground aux;
    string nameAux;

    string rootSkin = "Images/MenuCreate/P";
    int auxNumSkin = 0;
    bool pulsado = false;
    int pointsAvalible = 0;
    bool modificar = false;
    bool cargado = false;

    VisualElement returnToMenu;

    Individuo individuoPrueba;
    BaseDatos baseDatos = new BaseDatos();
    VisualElement saveButton;
    VisualElement loadButton;

    VisualTreeAsset plantilla;
    VisualElement tarjetaPlantilla;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        attackStats = root.Q<TextField>("AttackText");
        attack = root.Q<Stats>("Stats");
        defenseStats = root.Q<TextField>("DefenseText");
        defense = root.Q<Stats1>("Stats1");
        input_name = root.Q<TextField>("NameText");

        skin1 = root.Q<VisualElement>("P1");
        skin2 = root.Q<VisualElement>("P2");
        skin3 = root.Q<VisualElement>("P3");
        skin4 = root.Q<VisualElement>("P4");
        skinPos = root.Q<VisualElement>("PosTarget");

        create = root.Q<Button>("ButtonCreate");
        saveButton = root.Q<Button>("ButtonSave");
        loadButton = root.Q<Button>("ButtonLoad");

        returnToMenu = root.Q<Button>("ReturnMenu");
        returnToMenu.RegisterCallback<ClickEvent>(ReturnToMenu);

        attackStats.RegisterCallback<ChangeEvent<string>>(ChangeAttack);
        defenseStats.RegisterCallback<ChangeEvent<string>>(ChangeDefense);
        input_name.RegisterCallback<ChangeEvent<string>>(ChangeName);
        skin1.RegisterCallback<ClickEvent>(ChangeImage);
        skin2.RegisterCallback<ClickEvent>(ChangeImage);
        skin3.RegisterCallback<ClickEvent>(ChangeImage);
        skin4.RegisterCallback<ClickEvent>(ChangeImage);

        create.RegisterCallback<ClickEvent>(NuevaTarjeta);
        saveButton.RegisterCallback<ClickEvent>(GuardarIcono);
        
        loadButton.RegisterCallback<ClickEvent>(GargarIcono);
    }
    void ChangeAttack(ChangeEvent<string> e)
    {
        int newAttackValue;
        if (int.TryParse(e.newValue, out newAttackValue) && newAttackValue <= 5 && pointsAvalible - attack.NivelEspada + newAttackValue <= 5) // Intenta convertir el nuevo valor a int
        {
            pointsAvalible = pointsAvalible - attack.NivelEspada + newAttackValue;
            if (pointsAvalible <= 5)
            {
                Debug.Log(e.newValue);
                // Actualiza el valor de myEspada en la instancia de Stats
                attack.NivelEspada = newAttackValue;
            }
           
        }

    }
    void ChangeDefense(ChangeEvent<string> e)
    {
        int newDefenseValue;
        if (int.TryParse(e.newValue, out newDefenseValue) && newDefenseValue <= 5 && pointsAvalible - defense.NivelEscudo + newDefenseValue <= 5) // Intenta convertir el nuevo valor a int
        {
            pointsAvalible = pointsAvalible - defense.NivelEscudo + newDefenseValue;
            if (pointsAvalible <= 5)
            {
                Debug.Log(e.newValue);
                // Actualiza el valor de myEspada en la instancia de Stats
                defense.NivelEscudo = newDefenseValue;
            }
                
        }

    }
    void ChangeName(ChangeEvent<string> e)
    {

        if(e.newValue.Length < 10)
        {
            if(!modificar)
                nameAux = e.newValue;
            else
            {
                Debug.Log(e.newValue);
                individuoPrueba.Nombre = e.newValue;
                nameLabel.text = individuoPrueba.Nombre;
            }
                
        }
            
    }
    void ChangeImage(ClickEvent e)
    {
        VisualElement skins = e.target as VisualElement;
        Sprite per = null;
        if (pulsado)
        {
            Sprite normalImage = Resources.Load<Sprite>(rootSkin + "(" + auxNumSkin.ToString() + ")");
            auxSkin.style.backgroundImage = new StyleBackground(normalImage);
        }
        if (skins == skin1)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character1");
            Sprite hover = Resources.Load<Sprite>("Images/MenuCreate/P(1)Hover");

            skins.style.backgroundImage = new StyleBackground(hover);
            auxNumSkin = 1;
        }
        else if(skins == skin2)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character2");
            Sprite hover = Resources.Load<Sprite>("Images/MenuCreate/P(2)Hover");

            skins.style.backgroundImage = new StyleBackground(hover);
            auxNumSkin = 2;
        }
        else if(skins == skin3)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character3");
            Sprite hover = Resources.Load<Sprite>("Images/MenuCreate/P(3)Hover");

            skins.style.backgroundImage = new StyleBackground(hover);
            auxNumSkin = 3;
        }
        else if (skins == skin4)
        {
            per = Resources.Load<Sprite>("Images/MenuCreate/character4");
            Sprite hover = Resources.Load<Sprite>("Images/MenuCreate/P(4)Hover");

            skins.style.backgroundImage = new StyleBackground(hover);
            auxNumSkin = 4;
        }
        auxSkin = skins;
        pulsado = true;
        if (!modificar)
            aux = new StyleBackground(per);
        else
            individuoPrueba.Imagen.style.backgroundImage = new StyleBackground(per);
        
    }

    void GuardarIcono(ClickEvent evn)
    {
        baseDatos.saveData(AssetDatabase.GetAssetPath(individuoPrueba.Imagen.style.backgroundImage.value.sprite), individuoPrueba.Nombre);
    }
    void GargarIcono(ClickEvent e)
    {
        if (!cargado)
        {
            if(modificar)
                skinPos.Remove(tarjetaPlantilla);
            cargado = true;
            plantilla = Resources.Load<VisualTreeAsset>("Templates/skinTarget");
            Debug.Log(plantilla);
            tarjetaPlantilla = plantilla.Instantiate();



            Debug.Log("entra");
            skinPos.Add(tarjetaPlantilla);
            //tarjetas_borde_negro();
            //tarjetas_borde_blanco(tarjetaPlantilla);

            imagePrin = tarjetaPlantilla.Children().First();
            nameLabel = tarjetaPlantilla.Q<Label>("Nombre");


            Individuo individuo = new Individuo(nameLabel.text, imagePrin);
            (string, StyleBackground) datos = baseDatos.getData();
            individuo.Imagen.style.backgroundImage = datos.Item2;
            individuo.Nombre = datos.Item1;
            nameLabel.text = datos.Item1;
            //Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);
            individuoPrueba = individuo;
            modificar = true;
        }
       

    }
    void NuevaTarjeta(ClickEvent e)
    {
        plantilla = Resources.Load<VisualTreeAsset>("Templates/skinTarget");
        Debug.Log(plantilla);
        tarjetaPlantilla = plantilla.Instantiate();
       
        
        if (nameAux != null )
        {
            Debug.Log("entra");
           
            skinPos.Add(tarjetaPlantilla);
            
            //tarjetas_borde_negro();
            //tarjetas_borde_blanco(tarjetaPlantilla);

            imagePrin = tarjetaPlantilla.Children().First();
            nameLabel = tarjetaPlantilla.Q<Label>("Nombre");
            nameLabel.text = nameAux;
            imagePrin.style.backgroundImage = aux;

            Individuo individuo = new Individuo(nameLabel.text, imagePrin);
            //individuo.Imagen.style.backgroundImage = baseDatos.getData();
            //Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);
            individuoPrueba = individuo;
            modificar = true;
        }
            
        
        

        //individuos.Add(individuo);
        ////individuos.ForEach(elem =>
        ////{
        ////    Debug.Log(elem.Nombre + " " + elem.Apellido);
        ////    string jsonIndividuo = JsonUtility.ToJson(elem);
        ////    Debug.Log(jsonIndividuo);
        ////});
        //string listaToJson = JsonHelperIndividuo.ToJson(individuos, true);
        //Debug.Log(listaToJson);

        //List<Individuo> jsonLista = JsonHelperIndividuo.FromJson<Individuo>(listaToJson);
        //jsonLista.ForEach(i =>
        //{
        //    Debug.Log(i.Nombre + " " + i.Apellido);
        //});

    }

    private void ReturnToMenu(ClickEvent e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
