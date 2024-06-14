using UnityEngine;

namespace Runtime.Weapons.Bullets
{
    public class Parabolic : Bullet
    {
        [SerializeField] private float maxRaycastDistance = 30;
        [SerializeField] private float launchAngle = 75f;
        private Camera mainCamera;

        protected override void Awake()
        {
            base.Awake();
            mainCamera = Camera.main;
        }

        public override void Fire(float shootingForce)
        {
            Vector3 targetPosition = GetTargetPosition();
            if (targetPosition == Vector3.zero)
            {
                return;
            }

            Vector3 initialVelocity = CalculateInitialVelocity(targetPosition, shootingForce);
            if (initialVelocity != Vector3.zero)
            {
                bulletRigidBody.velocity = initialVelocity;
            }
        }

        private Vector3 GetTargetPosition()
        {
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            return Physics.Raycast(ray, out RaycastHit hit, maxRaycastDistance)
                ? hit.point
                : ray.GetPoint(maxRaycastDistance);
        }

        private Vector3 CalculateInitialVelocity(Vector3 targetPosition, float shootingForce)
        {
            Vector3 direction = targetPosition - bulletTransform.position;
            float horizontalDistance = new Vector2(direction.x, direction.z).magnitude;
            float verticalDistance = direction.y;
            float launchAngleInRadians = launchAngle * Mathf.Deg2Rad;

            float horizontalVelocity = Mathf.Cos(launchAngleInRadians) * shootingForce;
            float time = horizontalDistance / horizontalVelocity;

            // kinematic equation for uniformly accelerated motion
            float verticalVelocity = (verticalDistance + 0.5f * Mathf.Abs(Physics.gravity.y) * time * time) / time;

            Vector3 initialVelocity = new Vector3(direction.x, 0, direction.z).normalized * horizontalVelocity;
            initialVelocity.y = verticalVelocity;

            return initialVelocity;
        }
    }
}
