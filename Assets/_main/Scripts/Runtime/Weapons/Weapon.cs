using Runtime.Weapons.Bullets;
using UnityEngine;

namespace Runtime.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        [SerializeField] protected Transform spawnPoint;
        [SerializeField] private Collider weaponCollider;

        private float timeForNextShot;

        private Transform weaponTransform;

        private void Awake()
        {
            weaponTransform = transform;
        }

        private void Update()
        {
            if (timeForNextShot > 0)
            {
                timeForNextShot -= Time.deltaTime;
            }
        }

        public void Fire()
        {
            if (timeForNextShot > 0)
            {
                return;
            }
            Bullet bullet = Instantiate(weaponData.bullet, spawnPoint.position, spawnPoint.rotation, null);
            bullet.Fire(weaponData.shootingForce);
            timeForNextShot = weaponData.fireRate;
        }

        public void Grab(Transform holder)
        {
            weaponCollider.enabled = false;
            weaponTransform.position = holder.position;
            weaponTransform.rotation = holder.rotation;
            weaponTransform.SetParent(holder);
        }

        public void Drop()
        {
            weaponCollider.enabled = true;
            weaponTransform.SetParent(null);
            weaponTransform.position += new Vector3(weaponTransform.forward.x, -weaponTransform.position.y + weaponTransform.localScale.y, weaponTransform.forward.z);
            weaponTransform.rotation = Quaternion.identity;
        }
    }
}