using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StreamData
{

    private string _path;

    public void SetOptions(string path)
    {
        _path = Path.Combine(path, "Stringdata.txt");
    }

    public void Save(PlayerData playerData)
    {
        using (var sw = new StreamWriter(_path))
        {
            sw.WriteLine(playerData.Name);
            sw.WriteLine(playerData.HP);
            sw.WriteLine(playerData.IsVisible);
        }
        Debug.Log("DataSave" + _path);
    }

    public PlayerData Load()
    {
        var playerdata = new PlayerData();

        if (!File.Exists(_path)) return playerdata;

        using (var sr = new StringReader(_path))
        {
            playerdata.Name = sr.ReadLine();
            if (!float.TryParse(sr.ReadLine(), out playerdata.HP)) playerdata.HP = 100;
            if (!bool.TryParse(sr.ReadLine(), out playerdata.IsVisible)) playerdata.IsVisible = true;

        }

        Debug.Log("DataLoaded" + _path);
        return playerdata;
    }

}

