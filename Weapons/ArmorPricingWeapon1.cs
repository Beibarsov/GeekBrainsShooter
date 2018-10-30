﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public class ArmorPricingWeapon1 : BaseWeapon
    {

        [SerializeField]
        private Transform _firepoint;


        private void Awake()
        {
            _ammocurent = _ammomax;
        }

        public override void Fire()
        {
            if (!TryShoot()) return;

            BaseAmmo bullet = Instantiate(_bulletPrefab);
            bullet.Initialize(_firepoint, _force);

        }
        public override void Reload()
        {
            IsReloading = true;
            _lastreloadingtime = Time.time;
            Debug.Log("Пошла перезарядка");

        }

        private void Update()
        {
            //Сработка перезарядки
            if (IsReloading && Time.time - _lastreloadingtime > _reloadTime)
            {
                _ammocurent = _ammomax;
                IsReloading = false;
            }
        }
    }
}