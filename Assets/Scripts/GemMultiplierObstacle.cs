using UnityEngine;

public class GemMultiplierObstacle : MonoBehaviour
{
    [SerializeField] private int multiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            GameManager.instance.GemMultiplier = multiplier;
            Collector.instance.CameraTargetHeight += .75f;
        }
    }
}