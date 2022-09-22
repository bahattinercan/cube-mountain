using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 distance;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + distance, Time.deltaTime * 5f);
    }
}