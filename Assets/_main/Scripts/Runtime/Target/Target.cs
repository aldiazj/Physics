using UnityEngine;

namespace Runtime.Target
{
    public class Target : MonoBehaviour
    {
        private static readonly int DANCE_ANIMATION_PARAMETER = Animator.StringToHash("dance");

        [SerializeField] private Animator dancerAnimator;
        private static Dance ActualDance;

        private void OnEnable()
        {
            SetDance(ActualDance);
        }

        public void SetDance(Dance newDance)
        {
            dancerAnimator.SetInteger(DANCE_ANIMATION_PARAMETER, (int)newDance);
            ActualDance = newDance;
        }
    }
}
