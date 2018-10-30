using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Controller;
using Geekbrains.Views;

namespace Geekbrains
{



    public class Main : MonoBehaviour
    {
        //Синглтон, статическая точка входа в класс (единственный экземпляр класса)
        public static Main instance { get; private set; }

        public Player Player { get; private set; }
        public InputController InputController { get; private set; }
        public FlashlightController FlashlightController { get; private set; }
        public WeaponsController WeaponsController { get; private set; }
       // public FlashlightView FlashlightView { get; private set; }


        // Use this for initialization
        void Awake()
        {
            if (instance)
                DestroyImmediate(gameObject);
            else instance = this;
        }

        // Update is called once per frame
        void Start()
        {

            Player = FindObjectOfType<Player>();
            InputController = gameObject.AddComponent<InputController>();
            FlashlightController = gameObject.AddComponent<FlashlightController>();
            WeaponsController = gameObject.AddComponent<WeaponsController>();
           // FlashlightView = gameObject.AddComponent<FlashlightView>();
        }
    }
}