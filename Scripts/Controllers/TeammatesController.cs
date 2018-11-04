using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{

    public class TeammatesController : MonoBehaviour
    {
        //Делегат для выбора товарища
        public static Action<TeammateModel> OnTeammateSelected;

             
        private TeammateModel _currentTeammate;
        private Queue<Vector3> queue;


        private void Awake()
        {
            queue = new Queue<Vector3>();
        }

        /// <summary>
        /// Выбираем которым из товарищей управлять
        /// </summary>
        /// <param name="teammate"></param>
        public void SelectTeammate(TeammateModel teammate)
        {
            _currentTeammate = teammate;

            //Если на делегат кто-то подписан, срабатывает его вызов с передачей текущего товарища.
            if (OnTeammateSelected != null) OnTeammateSelected.Invoke(_currentTeammate);
        }

        /// <summary>
        /// Команды движения товарища   
        /// </summary>
        public void MoveCommand()
        {
            //Рэйкастим по с главной камеры по направлению позиции мыши
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Если рэйкаст куда-то попал
            if (Physics.Raycast(ray, out hit))
            {
                //Попал ли он в товарища (объект, имеющий компонент с моделью товарища)?
                TeammateModel teammate = hit.collider.GetComponent<TeammateModel>();
                //Если это товарищ, то наш товарищ теперь этот товарищ
                if (teammate) SelectTeammate(teammate);
                //Если наш товарищ уже определен, то указанная точка добавляется в очередь заданий
                else if (_currentTeammate) queue.Enqueue(hit.point);

            }

        }

        public void FixedUpdate()
        {
            if (queue.Count != 0 && _currentTeammate.IsRun == false) { 
            _currentTeammate.SetDestination(queue.Dequeue());
            }

        }


    }
}