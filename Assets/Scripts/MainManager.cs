using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/// <summary>
/// The parameter which wants to be accessed from the MainScence should be passed in this class.
/// </summary>
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColour;

    /// <summary>
    /// When the gameOject is being created, called this method.
    /// </summary>
    private void Awake()
    {
        //Start of a new code.
        //Check if the instance have been filled.If it is, then destroy the extra.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //end of it.

        //Set the instance equals to MainManager Scripts.Maybe?The Learn said that it can be called anywhere, have a try next time.
        Instance = this;
        //Even if the scence changed, the gameObject will not be destroyed anyway.
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    //Calling external libraries with using [].
    [System.Serializable]
    class SaveData
    {
        public Color TeamColour;
    }

    /// <summary>
    /// Transform the selected color to the json.
    /// </summary>
    public void SaveColor()
    {
        //Pass the willing-be-saved parameters in the date instance.
        SaveData data = new SaveData();
        data.TeamColour = TeamColour;

        //Transformed the instance to JSON with JsonUtility.ToJson
        string json = JsonUtility.ToJson(data);
        //Used the special method File.WriteAllText to write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    /// <summary>
    /// Load the parameter from the json to the TeamColor.
    /// </summary>
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        //Check if there a .json file exists.
        if (File.Exists(path))
        {
            //If it is, then read the path's content.
            string json = File.ReadAllText(path);
            //Transform the json to SaveData.
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            //Set the TeamColor to the color stored in the data.
            TeamColour = data.TeamColour;
        }
    }



}


