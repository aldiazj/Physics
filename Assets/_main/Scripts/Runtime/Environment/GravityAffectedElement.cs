using UnityEngine;

namespace Runtime.Environment
{
    public class GravityAffectedElement : MonoBehaviour
    {
        private bool wasForceApplied;
        private Transform elementTransform;
        private Rigidbody elementRigidBody;
        public Vector3 Position => elementTransform.position;
        public Rigidbody Rigidbody => elementRigidBody;


        private void Awake()
        {
            elementTransform = transform;
            elementRigidBody = GetComponent<Rigidbody>();
        }


        public void ApplyForce(Vector3 force)
        {
            elementRigidBody.useGravity = false;
            elementRigidBody.AddForce(force);
            wasForceApplied = true;
        }

        private void LateUpdate()
        {
            if (wasForceApplied)
            {
                wasForceApplied = false;
                return;
            }

            elementRigidBody.useGravity = true;
        }
    }
}