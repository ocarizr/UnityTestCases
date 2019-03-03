using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
    private const float MIN_SPEED = 2f;
    private const float MAX_SPEED = 20f;

    public Transform Player;

    [SerializeField] [Range(MIN_SPEED, MAX_SPEED)] private float _smoothSpeed;
    private Quaternion _lookRotation;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Player) return;

        _lookRotation = Quaternion.LookRotation(Player.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, _smoothSpeed * Time.deltaTime);
    }
}
