using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public class CivilCar : BaseObjectScene
    {

        public float Health = 20f;

        // Use this for initialization
        void Start()
        {
            IsEnemy = true;
        }


        public override void ApplyDamage(float damage, int typeDamage)
        {

            Debug.Log("Тип дамага" + typeDamage);
            if (Health <= 0) Die();
            
            if (typeDamage == 1)
                Health = Health - (50*damage);
            else
                Health -= damage;
            if (Health <= 0) Die();
        }

        // Update is called once per frame
        void Update()
        {
            


        }

        public void Die()
        {
            //Color = Color.red;
            Collider.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}