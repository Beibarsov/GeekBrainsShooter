﻿namespace Geekbrains
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BaseObjectScene : MonoBehaviour
    {

        protected int _layer;
        protected Material _material;
        protected Transform _myTransform;
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected Rigidbody _rigidbody;
        protected string _name;
        protected bool _isVisible;
        protected Color _color;
        protected Collider _collider;

        protected bool _IsEnemy;


        #region Property
        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }



        public bool IsEnemy
        {
            get { return _IsEnemy; }
            set { _IsEnemy = value; }
        }
        /// <summary>
        /// Слой объекта
        /// </summary>
        public int Layers
        {
            get { return _layer; }
            set
            {
                _layer = value;

                if (_instanceObject != null)
                {
                    _instanceObject.layer = _layer;
                }
                if (_instanceObject != null)
                {
                    AskLayer(GetTransform, value);
                }
            }
        }
        /// <summary>
        /// Цвет материала объекта
        /// </summary>
        public Material GetMaterial
        {
            get { return _material; }
        }

        /// <summary>
        /// Позиция объекта
        /// </summary>
        public Vector3 Position
        {
            get
            {
                if (InstanceObject != null)
                {
                    _position = GetTransform.position;
                }
                return _position;
            }
            set
            {
                _position = value;
                if (InstanceObject != null)
                {
                    GetTransform.position = _position;
                }
            }
        }
        /// <summary>
        /// Размер объекта
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                if (InstanceObject != null)
                {
                    _scale = GetTransform.localScale;
                }
                return _scale;
            }
            set
            {
                _scale = value;
                if (InstanceObject != null)
                {
                    GetTransform.localScale = _scale;
                }
            }
        }
        /// <summary>
        /// Поворот объекта
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                if (InstanceObject != null)
                {
                    _rotation = GetTransform.rotation;
                }

                return _rotation;
            }
            set
            {
                _rotation = value;
                if (InstanceObject != null)
                {
                    GetTransform.rotation = _rotation;
                }
            }
        }
        /// <summary>
        /// Получить физическое свойство объекта
        /// </summary>
        public Rigidbody GetRigidbody
        {
            get { return _rigidbody; }
        }
        /// <summary>
        /// Ссылка на gameObject
        /// </summary>
        public GameObject InstanceObject
        {
            get { return _instanceObject; }
        }
        /// <summary>
        /// Скрывает/показывает объект
        /// </summary>
        public bool IsVisible
        {
            get {
                //if (!_renderer)
                //   return false;

                return _isVisible;
            }
            set
            {
                _isVisible = value;
                SetVisibility(transform, _isVisible);
            }
        }

        private void SetVisibility(Transform transform, bool isVisible)
        {
            var rend = transform.GetComponent<Renderer>();
            if (rend)
                rend.enabled = isVisible;
            foreach (var r in GetComponentsInChildren<Renderer>(true))
                r.enabled = isVisible;
        }

        /// <summary>
        /// Получить Transform объекта
        /// </summary> 
        public Transform GetTransform
        {
            get { return _myTransform; }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                _material.color = _color;
            }
        }

        public Collider Collider
        {
            get { return _collider; }
        }

        #endregion

        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;
            if (GetComponent<Renderer>())
            {
                _material = GetComponent<Renderer>().material;
            }
            _rigidbody = _instanceObject.GetComponent<Rigidbody>();
            _collider = InstanceObject.GetComponent<Collider>();
            _myTransform = _instanceObject.transform;


            //_renderer = GetComponent<Renderer>();
            //if (_renderer)
            //    _material = _renderer.material;
            //if (_material)
            //    _color = _material.color;
        }

        #region PrivateFunction
        /// <summary>
        /// Выставляет слой себе и всем вложенным объектам независимо от уровня вложенности
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="lvl">Слой</param>
        private void AskLayer(Transform obj, int lvl)
        {
            obj.gameObject.layer = lvl;       // Выставляем объекту слой
            if (obj.childCount > 0)
            {
                foreach (Transform d in obj) // Проходит по всем вложенным объектам
                {
                    AskLayer(d, lvl);        // Рекурсивный вызов функции
                }
            }
        }


        public virtual void ApplyDamage(float damage, int typeDamage) {
            Debug.Log("Попадание в цель (родительское описание)");
        }

        #endregion

    }



}