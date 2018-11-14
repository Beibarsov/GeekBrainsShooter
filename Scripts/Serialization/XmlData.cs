using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;

public class XmlData {


    private string _path;

    public PlayerData Load()
    {
        var playerData = new PlayerData();
        if (!File.Exists(_path)) return playerData;

        using (XmlTextReader reader = new XmlTextReader(_path))
        {
            string key;
            //Пока читает
            while (reader.Read())
            {
                //Находит элемент по нужному ключу (названию) и вытягивает его атрибут (value) в качестве значения
                key = "Name";
                if (reader.IsStartElement(key)) playerData.Name = reader.GetAttribute("Value");

                key = "HP";
                if (reader.IsStartElement(key)) float.TryParse(reader.GetAttribute("Value") , out playerData.HP);

                key = "IsVisible";
                if (reader.IsStartElement(key)) bool.TryParse(reader.GetAttribute("Value"), out playerData.IsVisible);

            }
        }

        Debug.Log("Loaded");
        return playerData;
    }

    public void Save (PlayerData playerData)
    {
        //Создание документа
        var xmlDoc = new XmlDocument();
        //Создание элемента (главной ноды)
        XmlNode rootNode = xmlDoc.CreateElement("PlayerData");
        xmlDoc.AppendChild(rootNode);
        //Создание HP элемента
        var element = xmlDoc.CreateElement("HP");
        element.SetAttribute("Value", playerData.HP.ToString());
        rootNode.AppendChild(element);
        //Элемент Name
        element = xmlDoc.CreateElement("Name");
        element.SetAttribute("Value", playerData.Name.ToString());
        rootNode.AppendChild(element);
        //Элемент IsVisible
        element = xmlDoc.CreateElement("IsVisible");
        element.SetAttribute("Value", playerData.IsVisible.ToString());
        rootNode.AppendChild(element);

        xmlDoc.Save(_path);
        Debug.Log("Data Saved to " + _path);


    }

    public void SetOptions(string path)
    {
        _path = Path.Combine(path, "XmlData.xml");
    }





}
