using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Тестовая запись данных, инициализация сохранения
/// </summary>
public class TestData : MonoBehaviour {

    private void Start()
    {
        var path = Application.dataPath;
        Debug.Log(path);
        var playerData = new PlayerData { Name = "Player777", HP = 100f, IsVisible = true };

        Debug.Log("PlayerData" + playerData);

        var dataProvider = new PlayerPrefsData();
        dataProvider.SetOptions(path);
        dataProvider.Save(playerData);

        var loadedData = dataProvider.Load();
        Debug.Log("Loaded Data:" + loadedData);


    }

    
}
