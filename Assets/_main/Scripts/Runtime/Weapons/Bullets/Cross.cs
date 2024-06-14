using Runtime.Environment;
using UnityEngine;

namespace Runtime.Weapons.Bullets
{
    public class Cross : Bullet
    {
        [SerializeField] private float rotationForceMultiplier = 10000f;
        [SerializeField] private float liftingForce = 500f;

        public override void Fire(float shootingForce)
        {
            bulletRigidBody.AddForce(bulletTransform.forward * shootingForce, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out GravityAffectedElement gravityAffectedElement))
            {
                return;
            }
            Rigidbody targetRigidbody = gravityAffectedElement.Rigidbody;

            Vector3 directionToTarget = (targetRigidbody.position - bulletTransform.position).normalized;

            Vector3 rotationAxis = Vector3.Cross(bulletTransform.forward, directionToTarget).normalized;
            targetRigidbody.AddForce(Vector3.up*liftingForce);

            targetRigidbody.AddTorque(rotationAxis * rotationForceMultiplier, ForceMode.Impulse);
        }
    }
}