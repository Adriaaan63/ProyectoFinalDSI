using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuOptions : MonoBehaviour
{
    VisualElement returnToMenu;
    private List<AudioSource> audioSources; 

    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        VisualElement rootve = uIDocument.rootVisualElement;
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());

        TextoEnriquecido(rootve);
        createSlider(rootve);

        returnToMenu = rootve.Q<Button>("ReturnMenu");
        returnToMenu.RegisterCallback<ClickEvent>(ReturnToMenu);
    }

    private void ReturnToMenu(ClickEvent e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void TextoEnriquecido(VisualElement rootve)
    {
        Label texto = rootve.Q<Label>("OptinosText");
        texto.text = @"<b><gradient=""Options_colors"">OPTIONS <smallcaps> </gradient></b>";
    }

    private void createSlider(VisualElement rootve)
    {
        Slider slider = rootve.Q<Slider>("VolumeSlider");
        slider.style.backgroundColor = new Color(0.871f, 0.765f, 0.553f);  

        VisualElement mdrager = rootve.Q<VisualElement>("unity-dragger");
        mdrager.style.backgroundColor = new Color(1.0f, 0.92f, 0.016f); 

        VisualElement mtracker = rootve.Q<VisualElement>("unity-tracker");
        mtracker.style.backgroundColor = new Color(0.0f, 0.0f, 0.0f);

        slider.RegisterValueChangedCallback((evt) => {
            float mappedValue = evt.newValue / 100f;
            foreach (var source in audioSources)
            {
                source.volume = mappedValue;
            }
        });
    }
}
