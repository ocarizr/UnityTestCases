using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    public float SpeedH = 2.0f;
    public float SpeedV = 2.0f;

    private float _yaw = 0.0f;
    private float _pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime, Space.Self);
        }

        _yaw += SpeedH * Input.GetAxis("Mouse X");
        _pitch -= SpeedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
    }
}
