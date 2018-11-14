using System.Collections;
using UnityEngine;
namespace Geekbrains.Controller
{
    public sealed class FlashlightController : BaseController
    {


        // Ссылка на фонарик
        private FlashlightModel _light;

        // Время максимального заряда батарейки
         



        private void Awake()
        {
            _light = FindObjectOfType<FlashlightModel>();
            SetActiveFlashlight(false); // При старте сцены выключаем фонарик
           
        }
        public void Update()
        {
            if (!IsEnabled) return;       // Если контроллер неактивен, выходим из Update
                                        // Здесь описываем поведение фонарика: можно добавить максимальное время его работы, смену батареек и другое
        }
        private void SetActiveFlashlight(bool value)
        {
            _light.enabled = value;
        }
        /// <summary>
        /// Включить фонарик
        /// </summary>
        public override void On()
        {
            if (IsEnabled) return;          
            base.On();
            _light.On();
            SetActiveFlashlight(true);
            


        }
        /// <summary>
        ///  Выключить фонарик
        /// </summary>
        public override void Off()
        {
            if (!IsEnabled) return;
            _light.Off();
            base.Off();
            SetActiveFlashlight(false);   
        }

        public  void Switch()
        {
            if (IsEnabled)
            {
                Off();
            }
            else
            {
                On();
            }
        }

        

    }
}