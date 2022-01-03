using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager
{
    [RequireComponent(typeof(Collider2D))]
    public class SpawnPoint : MonoBehaviour
    {
        private Collider2D _collider;
        private Vector2 _halfSize;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _halfSize = new Vector2(_collider.bounds.size.x, _collider.bounds.size.y) / 2;
        }

        public Vector3 GetRandomSpawnPoint()
        {
            return _collider.bounds.center + new Vector3(Random.Range(-_halfSize.x, _halfSize.x), Random.Range(-_halfSize.y, _halfSize.y), 0);
        }

        private void OnDrawGizmosSelected()
        {
            if (!_collider) return;
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(_collider.bounds.center, _halfSize * 2);
        }
    }
}
