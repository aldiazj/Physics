using System.Collections;
using UnityEngine;

namespace Runtime.Weapons.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 3;

        protected Transform bulletTransform;
        protected Rigidbody bulletRigidBody;

        protected virtual void Awake()
        {
            bulletTransform = transform;
            bulletRigidBody = GetComponent<Rigidbody>();
            StartCoroutine(DestroyBullet());
        }

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }

        public abstract void Fire(float shootingForce);
    }
}