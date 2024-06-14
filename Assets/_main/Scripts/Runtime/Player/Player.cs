using Runtime.Input;
using Runtime.Weapons;
using UnityEngine;

namespace Runtime.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Movement movement;
        [SerializeField] private Transform weaponHolder;

        private bool hasWeaponAssigned;
        private Weapon weapon;

        private void Awake()
        {
            inputManager.onAxis += movement.Move;
            inputManager.onRightClick += FireWeapon;
            inputManager.onMouseMovement += movement.Rotate;
        }

        private void OnDestroy()
        {
            inputManager.onAxis -= movement.Move;
            inputManager.onRightClick -= FireWeapon;
            inputManager.onMouseMovement -= movement.Rotate;
        }

        private void FireWeapon()
        {
            weapon?.Fire();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Weapon grabbedWeapon))
            {
                return;
            }

            if (hasWeaponAssigned)
            {
                weapon.Drop();
            }
            weapon = grabbedWeapon;
            weapon.Grab(weaponHolder);
            hasWeaponAssigned = true;
        }
    }
}