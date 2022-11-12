using System;
using UnityEngine;

namespace Assets.Scripts.Guns
{
    internal class Bullet : MonoBehaviour
    {
        public float Damage { get; set; }

        public static event Action<float> HitEvent;

        private void OnCollisionEnter(Collision collision)
        {
            var enemyComponent = collision.gameObject.GetComponent<Enemy>();

            if (enemyComponent)
                HitEvent?.Invoke(Damage);

            Destroy(gameObject);
        }
    }
}
