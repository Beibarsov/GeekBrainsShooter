using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveLoadLevelObjects {

    [MenuItem("GeekBrains/Save Level")]
    private static void SaveObjects()
    {
        string path = Path.Combine(Application.dataPath, "LevelData.xml");
        GameObject[] levelObjs = GameObject.FindObjectsOfType<GameObject>();
        SerializableGameObject[] objectArray = new SerializableGameObject[levelObjs.Length];

        for (int i = 0; i < levelObjs.Length; i++)
        {
            objectArray[i] = new SerializableGameObject()
            {
                Name = levelObjs[i].name,
                Pos = levelObjs[i].transform.position,
                Rot = levelObjs[i].transform.rotation,
                Scale = levelObjs[i].transform.localScale,
                Tag = levelObjs[i].tag,
            };
        }

        XMLSerializator.Save(objectArray, path);

    }

    [MenuItem("GeekBrains/Load Level")]
    private static void LoadObjects()
    {

        string path = Path.Combine(Application.dataPath, "LevelData.xml");

        var objs = XMLSerializator.Load(path);

        foreach (var o in objs)
        {
            GameObject prefab = Resources.Load<GameObject>(o.Name);
            var tempObj = GameObject.Instantiate(prefab, o.Pos, o.Rot);
            tempObj.transform.localScale = o.Scale;
            tempObj.name = o.Name;
        }

    }
}
