using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Final : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        VisualElement rootve = uIDocument.rootVisualElement;

        CreateTemplates(rootve);
        TextoEnriquecido(rootve);

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
        texto.text = @"<b><gradient=""Horizontal_colors"">GAME <smallcaps> TITLE</smallcaps> </gradient></b>";
        
    }
}
