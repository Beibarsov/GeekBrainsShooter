using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{

    public class BaseWeaponView : MonoBehaviour
    {

        private SingleBarreledFireWeapon _model;
        private Text _text;

        // Use this for initialization
        void Awake()
        {
            _text = GetComponent<Text>();
            //_model = Get
            //_text.text = _model.AmmoCurent.ToString();


    }

        // Update is called once per frame
        void Update()
        {
           // _text.text = _model.AmmoCurent.ToString();
        }
    }
}
