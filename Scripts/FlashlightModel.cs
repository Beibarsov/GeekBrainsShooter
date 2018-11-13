using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public class FlashlightModel : BaseObjectScene
    {
        public Action<bool> OnLightSwitch;

        private Light _light;

        //Батарейка фонарика
        private float _batteryTimeLife = 10f;
        public float BatteryTimeLife
        {
            get { return _batteryTimeLife; }
        }

        public bool IsOn
        {
            get
            {
                if (_light == null) return false;
                return _light.enabled;
            }
        }

        private void Awake()
        {
            _light = GetComponent<Light>();
            _light.enabled = false;
            OnLightSwitch.Invoke(false);
        }

        public void On()
        {
            OnLightSwitch.Invoke(true);
            _light.enabled = true;
            StartCoroutine(BatteryCounter());



        }
        public void Off()
        {
            OnLightSwitch.Invoke(false);
            _light.enabled = false;
            StopAllCoroutines();
            _batteryTimeLife = 10f;
        }
        public void Switch()
        {
            if (IsOn) Off();
            else On();
        }

        //Коррутин разрядки АКБ
        IEnumerator BatteryCounter()
        {
            while (true)
            {
                Debug.Log(_batteryTimeLife);
                _batteryTimeLife--;
                if (_batteryTimeLife <= 0)
                {
                    Off();
                }
                yield return new WaitForSeconds(1f);


            }
        }

    }
}