using System;
using UnityEngine;
using UnityEngine.AI;

namespace Entity.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpriteFlipper))]
    [RequireComponent(typeof(Animator))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float _updateTime;
        private NavMeshAgent _agent;
        private GameObject _target;

        private Animator _animator;
        private float _latestPosition;
        private float _deltaXPosition;

        private SpriteFlipper _spriteFlipper;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
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
            // Check if agent moved in last destination update
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_animator.IsInTransition(0))
            {
                _deltaXPosition = transform.position.x - _latestPosition;
                _animator.Play(Mathf.Abs(_deltaXPosition) > 0 ? "EnemyRun" : "EnemyIdle");
                _latestPosition = transform.position.x;
            }
            
            // If no path, watch in targets direction
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
                //Debug.Log(e + gameObject.GetInstanceID().ToString());
            }
        }
    }
}