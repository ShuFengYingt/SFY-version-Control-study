using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        //Storing the colour which the player picked in the MainManager.
        MainManager.Instance.TeamColour = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        //While start, chose the color stored in the instance.
        ColorPicker.SelectColor(MainManager.Instance.TeamColour);
    }

    /// <summary>
    /// While click the start button , load the scene 1
    /// </summary>
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// If clicked the save, save the color
    /// </summary>
    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    /// <summary>
    /// If clicked the load, then load the color.
    /// </summary>
    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColour);
    }

    /// <summary>
    /// Exit the game.Using for exit button in the mune.
    /// </summary>
    public void Exit()
    {
        //While exict, save the color.
        MainManager.Instance.SaveColor();
        //Use #if to check which of the compiler the code be complied.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        //Use Application class and find the Quilt method to exit the game.
        Application.Quit(); 
#endif
    }
}
