using Runtime.Environment;
using UnityEngine;

namespace Runtime.Weapons.Bullets
{
    public class Gravitational : Bullet
    {
        private const float MIN_DISTANCE = 0.5f;

        [SerializeField] private float attractionRadius;
        [SerializeField] private float attractionForce = 20;

        public override void Fire(float shootingForce)
        {
            bulletRigidBody.velocity = bulletTransform.forward * shootingForce;
        }

        private void FixedUpdate()
        {
            const int MAX_COLLIDERS = 10;
            Collider[] hitColliders = new Collider[MAX_COLLIDERS];
            int numberOfColliders = Physics.OverlapSphereNonAlloc(bulletTransform.position, attractionRadius, hitColliders);
            for (int index = 0; index < numberOfColliders; index++)
            {
                Collider colliderInsideRadius = hitColliders[index];
                if (!colliderInsideRadius.TryGetComponent(out GravityAffectedElement gravityAffectedElement))
                {
                    continue;
                }

                Vector3 direction = bulletTransform.position - gravityAffectedElement.Position;
                float distance = direction.magnitude;

                if (distance < MIN_DISTANCE)
                {
                    continue;
                }

                float forceMagnitude = Mathf.Clamp(attractionForce / (distance * distance), 0, attractionForce);
                Vector3 force = direction.normalized * forceMagnitude;
                gravityAffectedElement.ApplyForce(force);
            }
        }
    }
}
