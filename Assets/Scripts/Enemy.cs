using Assets.Scripts.Guns;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Enemy : MonoBehaviour
    {
        private float _health = 100f;

        #region UnityMethods
        private void OnEnable()
        {
            Bullet.HitEvent += OnHit;
        }
        private void OnDisable()
        {
            Bullet.HitEvent -= OnHit;
        }
        #endregion

        private void OnHit(float damage)
        {
            _health = Mathf.Clamp(_health - damage, 0f, 100f);

            if (_health == 0)
                Destroy(gameObject);
        }
    }
}
