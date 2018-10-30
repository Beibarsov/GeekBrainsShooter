using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains { 

public abstract class BaseAmmo : BaseObjectScene {


        [SerializeField]
        protected float _damage = 20f;

        public abstract void Initialize(Transform firepoint, float force);
		
	}
}

