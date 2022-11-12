using UnityEngine;

namespace Assets.Scripts.Guns
{
    internal class Bullet : MonoBehaviour
    {
        public float Damage { get; set; }

        [SerializeField] private float MaxDistanceExistence;

        private float _distance;
        private Vector3 _lastPosition;

        #region UnityMethods
        private void Start()
        {
            _lastPosition = transform.position;
        }

        private void FixedUpdate()
        {
            _distance += Vector3.Distance(transform.position, _lastPosition);
            _lastPosition = transform.position;

            if (_distance >= MaxDistanceExistence)
                Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var enemyComponent = collision.gameObject.GetComponent<Enemy>();

            if (enemyComponent)
                enemyComponent.OnHit(Damage);

            Destroy(gameObject);
        }
        #endregion
    }
}
