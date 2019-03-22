using UnityEngine;

namespace Assets.Scripts.MagnifyingTestScripts
{
    public class PlayerController : MonoBehaviour
    {
        public float SpeedOfMovement;

        public float SpeedH = 2.0f;
        public float SpeedV = 2.0f;

        private float _yaw;
        private float _pitch;

        // Update is called once per frame
        void Update()
        {
            float movement = SpeedOfMovement * Time.deltaTime;
            // Forward or Backward
            if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * movement, Space.Self);
            else if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * movement, Space.Self);
            // Left or Right
            if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left * movement, Space.Self);
            else if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * movement, Space.Self);
            // Up or down
            if (Input.GetKey(KeyCode.Q)) transform.Translate(Vector3.up * movement, Space.Self);
            else if (Input.GetKey(KeyCode.E)) transform.Translate(Vector3.down * movement, Space.Self);

            _yaw += SpeedH * Input.GetAxis("Mouse X");
            _pitch -= SpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(_pitch, _yaw + 180, 0.0f);
        }
    }
}
