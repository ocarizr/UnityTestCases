using UnityEngine;

namespace Assets.Scripts.TouchInput_Scripts
{
    public class TouchInput : MonoBehaviour
    {
        private const float DeltaTolerance = 2f;

        #region Edit_on_Inspector

        public Camera Camera;
        public float RotationSpeed;
        public float DragSpeed;
        public float ZoomSpeed;
        
        #endregion

        private float _lastDistance;

        private void Update()
        {
            switch (Input.touchCount)
            {
                case 1: // Rotating
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        RotateCamera();
                    }
                    break;
                case 2: // Panning and Zooming
                    if (Input.GetTouch(1).phase == TouchPhase.Began)
                        _lastDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

                    if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
                    {
                        float distance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                        float delta = distance - _lastDistance;
                        if (Mathf.Abs(delta) < DeltaTolerance) // Pan
                        {
                            PanCamera();
                        }
                        else // Zoom
                        {
                            ZoomCamera(delta);
                        }
                        _lastDistance = distance;
                    }
                    break;
            }
        }

        private void PanCamera()
        {
            Vector2 delta = Input.GetTouch(0).deltaPosition;
            transform.Translate(new Vector3(delta.x * DragSpeed, -delta.y * DragSpeed, 0), Space.Self);
        }

        private void RotateCamera()
        {
            Vector2 delta = Input.GetTouch(0).deltaPosition;
            Vector3 localRotation = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(localRotation.x + (delta.y * RotationSpeed),
                localRotation.y + (delta.x * RotationSpeed), transform.localRotation.eulerAngles.z);
        }

        private void ZoomCamera(float delta)
        {
            Vector3 cameraPos = Camera.transform.localPosition;
            Camera.transform.localPosition = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z + delta * ZoomSpeed);
        }
    }
}
