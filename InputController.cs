using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Geekbrains.Controller
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("SwitchFlashlight"))
            {

                Debug.Log("Клик");
                Main.instance.FlashlightController.Switch();
            }

            if (Input.GetButtonDown("ChangeWeapon") || Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Main.instance.WeaponsController.ChangeWeapon();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Main.instance.WeaponsController.Fire();
                
            }

            if (Input.GetButtonDown("Reload") )
            {
                Main.instance.WeaponsController.Reload();

            }

        }
         
    }
}