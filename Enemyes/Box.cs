using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Geekbrains
{

    public class Box : BaseObjectScene
    {
       
        
        public float Health = 100f;

        private void Start()
        {
            //Именно флаг IsEnemy говорит, что пули при попападании наносят урон (с различными вариантами взаимодействия)
            IsEnemy = true;
            Scale = new Vector3(2f, 2f, 1);
        }


        /// <summary>
        /// Обработка получаемого урона
        /// </summary>
        /// <param name="damage">Сколько единиц урона нанесено объекту</param>
        public override void ApplyDamage(float damage, int typeDamage)
        {

            Debug.Log("Попадание в цель");
            if (Health <= 0) return;
            Health -= damage;
            Color = Random.ColorHSV();

            if (Health <= 0) Die();



        }

        /// <summary>
        /// Обработка смерти объекта
        /// </summary>
        public void Die()
        {
            Color = Color.red;
            Collider.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}