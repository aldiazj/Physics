using Runtime.Weapons.Bullets;
using UnityEngine;

namespace Runtime.Weapons
{
    [CreateAssetMenu(menuName = "Create WeaponData", fileName = "WeaponData", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public Bullet bullet;
        public float fireRate;
        public float shootingForce;
    }
}