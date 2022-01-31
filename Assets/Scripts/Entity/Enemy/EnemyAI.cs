using System;
using UnityEngine;
using UnityEngine.AI;

namespace Entity.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpriteFlipper))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float _updateTime;
        private NavMeshAgent _agent;
        private GameObject _target;

        private SpriteFlipper _spriteFlipper;

        private void Awake()
        {
            _spriteFlipper = GetComponent<SpriteFlipper>();
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
            if (!_agent.hasPath)
                _spriteFlipper.FlipSprite(_target.transform.position.x > transform.position.x);
            
            try
            {
                if (!_target.activeSelf) return;
                
                NavMeshPath path = new NavMeshPath();
                _agent.CalculatePath(_target.transform.position, path);
                _agent.SetPath(path.status == NavMeshPathStatus.PathPartial ? null : path);

                // Check path future position to flip sprite
                if (path.corners.Length >= 2)
                    _spriteFlipper.FlipSprite(path.corners[1].x > transform.position.x);
            }
            catch (Exception e)
            {
                Debug.Log(e + gameObject.GetInstanceID().ToString());
            }
        }
    }
}