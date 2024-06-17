using UnityEngine;

namespace Runtime.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float yawSpeed;
        [SerializeField] private float pitchSpeed;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform characterTransform;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        private float xRotation;

        public void Move(Vector2 axes)
        {
            Vector3 forward = characterTransform.forward;
            Vector3 right = characterTransform.right;

            Vector3 direction = (forward * axes.y + right * axes.x).normalized;

            characterController.Move(direction * (movementSpeed * Time.deltaTime));
        }

        public void Rotate(Vector2 axes)
        {
            float yaw = axes.x * yawSpeed * Time.deltaTime;
            characterTransform.Rotate(Vector3.up * yaw);

            float pitch = axes.y * pitchSpeed * Time.deltaTime;
            xRotation -= pitch;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}