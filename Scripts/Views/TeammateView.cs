using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Controller;
using System;

namespace Geekbrains.Views
{


    public class TeammateView : BaseObjectScene
    {

        private TeammateModel _model;

        protected override void Awake()
        {
            base.Awake();

            _model = GetComponentInParent<TeammateModel>();

            TeammatesController.OnTeammateSelected += TeammateSelected;
            IsVisible = false;
        }

        private void TeammateSelected(TeammateModel model)
        {
            IsVisible = _model == model;
        }

        private void OnDestroy()
        {
            TeammatesController.OnTeammateSelected -= TeammateSelected;
        }
    }
}
