using UnityEngine;

namespace Assets.Scripts.Guns
{
    internal class SimpleGun : AbstractGun
    {
        #region SerializeFields
        [SerializeField] private GameObject BulletPrefab;
        [SerializeField] private Transform ShootingPoint;
        [SerializeField] private float Damage;
        [SerializeField] private float Impulse;
        #endregion

        public override void Shoot()
        {
            var bullet = Instantiate(BulletPrefab, ShootingPoint.position, Quaternion.Euler(0, 0, 0));

            bullet.GetComponent<Bullet>().Damage = Damage;
            bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Impulse, ForceMode.Impulse);
        }
    }
}