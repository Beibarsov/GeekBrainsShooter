using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{



    public abstract class BaseWeapon : BaseObjectScene
    {

        [SerializeField]
        protected float _force; //Сила выстрела
        [SerializeField]
        protected float _reloadTime; //Время перезарядки
        [SerializeField]
        protected float _timeoute; //Таймаут перед следующим выстрелом
        [SerializeField]
        protected int _ammomax; //Макс. патронов в обойме
        [SerializeField]
        protected BaseAmmo _bulletPrefab;

        private float _lastshottime; //Время предыдущего (последего) выстрела
        protected bool IsReloading; //Перезаряжается ли оружие
        protected float _lastreloadingtime; //Время постановки на перезарядку
        protected int _ammocurent; //Патронов в обойме сейчас

        public int AmmoCurent
        {
            get { return _ammocurent; }
        }


        public abstract void Fire();

        public abstract void Reload();

        protected bool TryShoot()
        {
            if (Time.time - _lastshottime < _timeoute)
                return false;
            if (_ammocurent <= 0)
                return false;
            if (IsReloading)
                return false;

            _lastshottime = Time.time;
            _ammocurent--;
            return true;
        }


    }
}
