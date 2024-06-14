using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Input
{
    public class InputManager : MonoBehaviour
    {
        public UnityAction<Vector2> onAxis;
        public UnityAction<Vector2> onMouseMovement;
        public UnityAction onRightClick;
        private void Update()
        {
            float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            float vertical = UnityEngine.Input.GetAxis("Vertical");
            float mouseX = UnityEngine.Input.GetAxis("Mouse X");
            float mouseY = UnityEngine.Input.GetAxis("Mouse Y");

            if (horizontal != 0 || vertical != 0)
            {
                onAxis?.Invoke(new Vector2(horizontal, vertical));
            }

            if (mouseX != 0 || mouseY != 0)
            {
                onMouseMovement?.Invoke(new Vector2(mouseX, mouseY));
            }

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                onRightClick?.Invoke();
            }
        }
    }
}
