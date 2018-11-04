using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{
    public class BaseController : MonoBehaviour
    {
        public bool IsEnabled { get; private set; }

        public virtual void On()
        {
            IsEnabled = true;
        }

        public virtual void Off()
        {
            IsEnabled = false;
        }


    }
}