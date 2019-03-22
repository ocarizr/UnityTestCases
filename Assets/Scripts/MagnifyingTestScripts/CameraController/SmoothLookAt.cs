using UnityEngine;

namespace Assets.Scripts.MagnifyingTestScripts.CameraController
{
    public class SmoothLookAt : MonoBehaviour
    {
        private const float MinSpeed = 2f;
        private const float MaxSpeed = 20f;

        public Transform Player;

        [SerializeField] [Range(MinSpeed, MaxSpeed)] private readonly float _smoothSpeed = MinSpeed;
        private Quaternion _lookRotation;

        // Update is called once per frame
        private void LateUpdate()
        {
            if (!Player) return;

            _lookRotation = Quaternion.LookRotation(Player.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, _smoothSpeed * Time.deltaTime);
        }
    }
}
