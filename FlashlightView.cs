using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains.Views
{

    public class FlashlightView : MonoBehaviour
    {
        [SerializeField]
        private Color _onColor;
        [SerializeField]
        private Color _offColor;

        private FlashlightModel _model;
        private Image _image; 

        // Use this for initialization
        void Awake()
        {

            //Картинка-индикатор включения фонарика
           _image = GetComponent<Image>();
            //Текст-счетчик батареи.
            //_batteryCounter = GetComponent<Text>();
           _model = FindObjectOfType<FlashlightModel>();
           _model.OnLightSwitch += FlashlightSwitch;

            FlashlightSwitch(_model.IsOn);

            //_model.OnLightSwitch.Invoke(false);

        }

        private void OnDestroy()
        {
            _model.OnLightSwitch -= FlashlightSwitch;
        }

        private void Update()
        {
            if (_model.OnLightSwitch != null) Debug.Log("Фонарик существует");
            //_image.color = _model.IsOn ? _onColor : _offColor;
        }


        private void FlashlightSwitch(bool state)
        {
            //Если state равно тру, значит ОнКолор, если нет - оффколор.
            _image.color = state ? _onColor : _offColor;
         //   Debug.Log("Изменение состояния");
        }

    }
}