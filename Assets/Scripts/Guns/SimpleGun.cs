using UnityEngine;

namespace Assets.Scripts.Guns
{
    internal class SimpleGun : AbstractGun
    {
        #region SerializeFields
        [SerializeField] private GameObject BulletPrefab;
        [SerializeField] private Transform ShootingPoint;
        [SerializeField] private float Damage;
        [SerializeField] private float BulletVelocity;
        #endregion

        public override void Shoot()
        {
            var bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
            var bulletRigidBody = bullet.GetComponent<Rigidbody>();

            bullet.GetComponent<Bullet>().Damage = Damage;
            bulletRigidBody.AddRelativeForce(bulletRigidBody.mass * BulletVelocity * Vector3.forward, ForceMode.Impulse);
        }
    }
}