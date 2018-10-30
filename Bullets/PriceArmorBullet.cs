using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public class PriceArmorBullet : BaseAmmo
    {

        [SerializeField]
        private float _destroyTime = 5f;
        [SerializeField]
        private LayerMask _layerMask;


        private bool _isHitted; //Попали ли
        private float _speed;


        public override void Initialize(Transform firepoint, float force)
        {

            //Пуля летит оттуда и в том направлении, где и куда повернут firepoint (точка спавна)
            transform.position = firepoint.position;
            transform.rotation = firepoint.rotation;

            _speed = force;

            //Пуля самоудалиться через некоторое время, достаточное, чтобы улететь далеко-далеко. 
            Destroy(gameObject, _destroyTime);
        }


        private void FixedUpdate()
        {

            //Ниженаписанное регулирует поведение пули

            //Если пуля куда-то попала, то делать с ней ничего не нужно
            if (_isHitted) return;

            //Рассчет точки, куда пуля прилетит по итогам "физического кадра"
            var finalPos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;

            //Объявление RaycastHit, "цели"
            RaycastHit hit;

            //Кидаем лайнскаст с позиции пули до finalpos, стреляет она в рамках _layerMask и на выход отдаёт тот самый hit
            //Условие срабатывает, если hit появился, т.е. != null.
            if (Physics.Linecast(transform.position, finalPos, out hit, _layerMask))
            {

                //Записываем вспомогательную переменную как "есть попадание"
                _isHitted = true;
                //Пуля ставится в точку попадания
                transform.position = hit.point;

                //Кэшируем Rigidbody объекта, в который попали
                var rb = hit.collider.GetComponent<Rigidbody>();
                //Если оно есть, толкаем объект в который попали
                if (rb) rb.AddForce(transform.forward * _speed);

                //Кэшируем врага, в которого попали
                var enemy = hit.collider.GetComponentInChildren<BaseObjectScene>();
                if (enemy != null) Debug.Log(enemy.IsEnemy);
                if (enemy != null && enemy.IsEnemy) enemy.ApplyDamage(_damage, 1);

                //Пуля после попадания вскоре самуоничтожается
                Destroy(gameObject, 0.3f);
            }
            //Если попадания на данном апдейте не случилось, то пуля просто перелетает в finalpos.
            else
            {
                transform.position = finalPos;
            }
        }
    }



}