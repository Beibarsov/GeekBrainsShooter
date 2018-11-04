using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Geekbrains
{


    public class TeammateModel : BaseObjectScene
    {

        private NavMeshAgent _agent;             // the navmesh agent required for the path finding
        private ThirdPersonCharacter _character; // the character we are controlling
        public bool IsRun { get; set; }
        //public Transform target;                                    // target to aim for


        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _character = GetComponent<ThirdPersonCharacter>();



            _agent.updatePosition = true ;
            _agent.updateRotation = false;
        }

        private void Update()
        {
            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                _character.Move(_agent.desiredVelocity, false, false);
                IsRun = true;
            }
                
            else { 
                _character.Move(Vector3.zero, false, false);
                IsRun = false;

            }

        }

        public void SetDestination(Vector3 pos)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(pos, out hit, 5f, -1))
            {
                _agent.SetDestination(hit.position);

            }
            else
            {
                Debug.Log("Позиция недостижима");
            }
        }
    }


    
}