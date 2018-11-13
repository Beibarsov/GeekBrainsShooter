using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public static class XMLSerializator
{
    private static XmlSerializer _serializer;

    static XMLSerializator()
    {
        _serializer = new XmlSerializer(typeof(SerializableGameObject[]));
    }

    public static void Save(SerializableGameObject[] levelObjs, string path)
    {
        if (levelObjs == null || levelObjs.Length == 0 || string.IsNullOrEmpty(path)) return;

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            _serializer.Serialize(fs, levelObjs);
        }
    }

    public static SerializableGameObject[] Load(string path)
    {
        if (!File.Exists(path)) return null;
        SerializableGameObject[] result;
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            result = (SerializableGameObject[])_serializer.Deserialize(fs);
        }

        return result;
    }

}

