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
            // Get the character's forward and right directions
            Vector3 forward = characterTransform.forward;
            Vector3 right = characterTransform.right;

            // Calculate the direction to move based on input and character orientation
            Vector3 direction = (forward * axes.y + right * axes.x).normalized;

            // Move the character controller in the calculated direction
            characterController.Move(direction * (movementSpeed * Time.deltaTime));
        }

        public void Rotate(Vector2 axes)
        {
            float yaw = axes.x * yawSpeed * Time.deltaTime;
            characterTransform.Rotate(Vector3.up * yaw);

            float pitch = axes.y * pitchSpeed * Time.deltaTime;
            xRotation -= pitch;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the pitch to avoid flipping
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}