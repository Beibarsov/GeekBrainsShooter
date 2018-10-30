using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{



    public class CubeModel : BaseObjectScene
    {

        private void Start()
        {
            GetRigidbody.mass = 100;
            Scale = new Vector3(4f, 2f, 1);
        }
        
    }
}
