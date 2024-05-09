using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Final : MonoBehaviour
{

    VisualElement botonOptions;
    VisualElement botonNewGame;
    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        VisualElement rootve = uIDocument.rootVisualElement;

        botonOptions = rootve.Q<Button>("options");
        botonNewGame = rootve.Q<Button>("newGame");
        TextoEnriquecido(rootve);

        botonOptions.RegisterCallback<ClickEvent>(CambiarAOptions);
        botonNewGame.RegisterCallback<ClickEvent>(CambiarAGame);
    }
    private void CreateTemplates(VisualElement rootve)
    {
        VisualElement ButtonsMenu = rootve.Q("ButtonsMenu");

        VisualTreeAsset buttonsPanelMenu = Resources.Load<VisualTreeAsset>("Templates/Column1");

        VisualElement buttonsIzq = buttonsPanelMenu.Instantiate();

        ButtonsMenu.Add(buttonsIzq);


    }
    private void TextoEnriquecido(VisualElement rootve)
    {
        Label texto = rootve.Q<Label>("Title");
        texto.text = @"<b><gradient=""Horizontal_colors""><smallcaps>Realms' Destiny</smallcaps> </gradient></b>";
        
    }

    private void CambiarAOptions(ClickEvent e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void CambiarAGame(ClickEvent e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
