using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuItems : MonoBehaviour
{
    private static string _prefabsFolder = "Prefabs";
    private static string _MaterialsFolder = "Materials";
    private static string _ScriptsFolder = "Scripts";
    private static string _ScenesFolder = "Scenes";
    private static string _AudioFolder = "Audio";

    [MenuItem("Extra/Toggle Selected")]
    static void ToggleSelectedObjects()
    {
        //Debug.Log("Selection: " + Selection.activeTransform.gameObject.name);
        ToggleObjects toggleObjects = new ToggleObjects();
        toggleObjects.ToggleSelectedObjects();
    }

    [MenuItem("Extra/Create Folders")]
    static void CreateFolder()
    {
        Debug.Log("Folder maker!");
        //if materials folder doesn't exist, make it
        string materialsPath = $"{Application.dataPath}/{_MaterialsFolder}";
        if (!Directory.Exists(materialsPath))
        {
            Directory.CreateDirectory(materialsPath);
        }

        string PrefabsPath = $"{Application.dataPath}/{_prefabsFolder}";
        if (!Directory.Exists(PrefabsPath))
        {
            Directory.CreateDirectory(PrefabsPath);
        }

        string ScriptsPath = $"{Application.dataPath}/{_ScriptsFolder}";
        if (!Directory.Exists(ScriptsPath))
        {
            Directory.CreateDirectory(ScriptsPath);
        }

        string ScenesPath = $"{Application.dataPath}/{_ScenesFolder}";
        if (!Directory.Exists(ScenesPath))
        {
            Directory.CreateDirectory(ScenesPath);
        }

        string AudioPath = $"{Application.dataPath}/{_AudioFolder}";
        if (!Directory.Exists(AudioPath))
        {
            Directory.CreateDirectory(AudioPath);
        }
        //refresh unity database to load changes
        AssetDatabase.Refresh();
    }

    [MenuItem("Extra/Create Materials")]
    static void MakeMaterials()
    {
        //make sure there's a materials folder at all
        string materialsPath = $"{Application.dataPath}/{_MaterialsFolder}";
        if (!Directory.Exists(materialsPath))
        {
            Directory.CreateDirectory(materialsPath);
        }
        //get dictionary with all material names and values
        MatsDictionary ColorsDict = new MatsDictionary();
        ColorsDict.PopulateDictionary();
        Dictionary<string, Color> colors = ColorsDict.GetDictionary();

        //loop thru keys in dictionary and create materials
        //keyvalue pair, name for thing, IN dictionary
        foreach(KeyValuePair<string,Color> matColor in colors)
        {
            Material mat = new Material(Shader.Find("Standard"));
            //create thing - the object, and then the file path - matcolor.key names the thing after the key
            AssetDatabase.CreateAsset(mat, $"Assets/{_MaterialsFolder}/{ matColor.Key}.mat");
            //apply value to material named after key
            mat.color = matColor.Value;
        }
        AssetDatabase.Refresh();
    }
}

public class MatsDictionary
{
    //make dictionary of colors
    private Dictionary<string, Color> colors = new Dictionary<string, Color>();

    public void PopulateDictionary()
    {
        //put values in dictionary
        //colors are RGBA - red, green, blue, alpha!
        colors.Add("Red_M", new Color(1f, 0.2f, 0.2f, 1f));
        colors.Add("Blue_M", new Color(0.2f, 0.2f, 1f, 1f));
        colors.Add("Green_M", new Color(0.2f, 1f, 0.2f, 1f));
        colors.Add("Cyan_M", new Color(0.2f, 1f, 1f, 1f));
        colors.Add("Yellow_M", new Color(1f, 1f, 0.2f, 1f));
        colors.Add("Orange_M", new Color(1f, 0.5f, 0.2f, 1f));
        colors.Add("Purple_M", new Color(1f, 0.2f, 1f, 1f));
    }

    public Dictionary<string,Color> GetDictionary()
    {
        return colors;
    }
}

public class ToggleObjects
{
    public void ToggleSelectedObjects()
    {
        GameObject[] currentObjects = Selection.gameObjects;
        if(currentObjects != null)
        {
            //loop thru selected objects, toggle active state
            foreach (GameObject currentObj in currentObjects)
            {
                //reverse enabled state of object
                bool isEnabled = currentObj.activeSelf;
                isEnabled = !isEnabled;
                currentObj.SetActive(isEnabled);
            }
        }
    }
}