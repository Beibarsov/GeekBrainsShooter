using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;

public class JsonData
{


    private string _path;

    public PlayerData Load()
    {
        var playerData = new PlayerData();
        if (!File.Exists(_path)) return playerData;

        var str = File.ReadAllText(_path);
        playerData = JsonUtility.FromJson<PlayerData>(str);

        Debug.Log("Loaded");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {


        var str = JsonUtility.ToJson(playerData);
        File.WriteAllText(_path, str);
        Debug.Log("Data Saved to " + _path);


    }

    public void SetOptions(string path)
    {
        _path = Path.Combine(path, "JsonData.json");
    }





}
