using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow {

    public GameObject ObjectInstantiate;
    string _nameObject = "Hello World";
    bool groupEnabled;
    bool _randomColor = true;
    int _countObject = 1;
    float _radius = 10;
    Color[] _colors = new Color[]
    {
        Color.gray, Color.black, Color.blue
    };
    List<GameObject> _createdObj = new List<GameObject>();


    [MenuItem("GeekBrains/MyFirstWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
        ObjectInstantiate = EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate, typeof(GameObject), true) as GameObject;
        _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
        groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
        _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
        _countObject = EditorGUILayout.IntSlider("Количество объектов", _countObject, 1, 100);
        _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10, 50);
        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Создать объекты"))
        {
            if (ObjectInstantiate)
            {
                GameObject root = new GameObject("Root");
                for (int i =0; i < _countObject; i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject;
                    Vector3 pos = new Vector3(Mathf.Cos(angle), i, Mathf.Sin(angle)) * _radius;
                    GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity) as GameObject;
                    temp.name = _nameObject + "(" + i + ")";
                    if (temp.GetComponent<Renderer>() && _randomColor)
                    {
                        temp.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length - 1)];
                    }
                    _createdObj.Add(temp);
                }
                Debug.Log(_createdObj.Count);
                DestroyImmediate(root);
            }
        }
        if (GUILayout.Button("Удалить созданные объекты"))
        {
            for (int i = 0; i < _createdObj.Count; i++)
            {
                DestroyImmediate(_createdObj[i]);
                
            }
            _createdObj.Clear();
        }





    }



}
