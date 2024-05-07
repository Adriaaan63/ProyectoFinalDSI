using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuOptions : MonoBehaviour
{
    VisualElement returnToMenu;
    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        VisualElement rootve = uIDocument.rootVisualElement;

        returnToMenu = rootve.Q<Button>("ReturnMenu");

        returnToMenu.RegisterCallback<ClickEvent>(ReturnToMenu);
    }

    private void ReturnToMenu(ClickEvent e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
