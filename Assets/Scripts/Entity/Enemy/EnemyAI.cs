using System;
using UnityEngine;
using UnityEngine.AI;

namespace Entity.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float _updateTime;
        private NavMeshAgent _agent;
        private GameObject _target;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Start()
        {
            if (!_target) _target = GameObject.FindWithTag("Player");
            InvokeRepeating(nameof(SetDestination), 0, _updateTime);
        }

        private void SetDestination()
        {
            try
            {
                NavMeshPath path = new NavMeshPath();
                _agent.CalculatePath(_target.transform.position, path);
                _agent.SetPath(path.status == NavMeshPathStatus.PathPartial ? null : path);
            }
            catch (Exception e)
            {
                Debug.Log(e + gameObject.GetInstanceID().ToString());
            }
        }
    }
}