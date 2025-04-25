using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 rawTargetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            rawTargetPos.x = Mathf.Clamp(rawTargetPos.x, minPosition.x, maxPosition.x);
            rawTargetPos.y = Mathf.Clamp(rawTargetPos.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.SmoothDamp(transform.position, rawTargetPos, ref velocity, smoothTime);
        }
    }
}