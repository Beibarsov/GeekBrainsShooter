using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;
public class PlayerPrefsData
{

    private string _path;

    public PlayerData Load()
    {
        var playerData = new PlayerData();


        playerData.Name = PlayerPrefs.GetString("Name", playerData.Name);
        playerData.HP = PlayerPrefs.GetFloat("HP", playerData.HP);
        if (!bool.TryParse(PlayerPrefs.GetString("IsVisible", playerData.IsVisible.ToString()), out playerData.IsVisible)) playerData.IsVisible = true;

        Debug.Log("Loaded");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {

        PlayerPrefs.SetString("Name", playerData.Name);
        PlayerPrefs.SetFloat("HP", playerData.HP);
        PlayerPrefs.SetString("IsVisible", playerData.IsVisible.ToString());
        

        Debug.Log("Data Saved");
        PlayerPrefs.Save();


    }

    public void SetOptions(string path)
    {
        _path = Path.Combine(path, "JsonData.json");
    }
}
