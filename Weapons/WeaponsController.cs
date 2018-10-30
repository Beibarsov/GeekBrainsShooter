using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller { 

public class WeaponsController : BaseController {

        private BaseWeapon[] _weapons;
        private int _currentWeapon;



        public void Awake()
        {
            _weapons = Main.instance.Player.GetComponentsInChildren<BaseWeapon>(true);

            for (int i = 0; i < _weapons.Length; i++)
            {
                _weapons[i].IsVisible = i == 0;
            }
        }

        public void ChangeWeapon()
        {
            _weapons[_currentWeapon].IsVisible = false;
            _currentWeapon++;
            if (_currentWeapon >= _weapons.Length) _currentWeapon = 0;
            _weapons[_currentWeapon].IsVisible = true;
        }

        public void Fire()
        {
            if (_weapons.Length > _currentWeapon && _weapons[_currentWeapon])
                _weapons[_currentWeapon].Fire();
             
        }

        public void Reload()
        {
            _weapons[_currentWeapon].Reload();
        }
    }
} 
