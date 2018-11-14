using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Lesson5))]
public class Lesson5Editor : Editor {


    bool _isButtonPressed;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Lesson5 les5 = (Lesson5)target;
        var pressButton = GUILayout.Button("Создать объекты", EditorStyles.miniButton); 

        if (pressButton)
        {
            les5.CreateObj();
            _isButtonPressed = true;
        }

        if (_isButtonPressed)
        {
            EditorGUILayout.HelpBox("Кнопка нажата!", MessageType.Info);
        }
    }
}
