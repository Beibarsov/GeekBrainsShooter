using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains.Views
{


    public class FlashlightViewCounter : MonoBehaviour
    {

        private FlashlightModel _model;
        private Text _text;


        private void Awake()
        {
            //_text = GetComponent<Text>();
           // _model = FindObjectOfType<FlashlightModel>();

        }


         void Update()
        {
            //_text.text = _model.BatteryTimeLife.ToString();
        }


    }

}