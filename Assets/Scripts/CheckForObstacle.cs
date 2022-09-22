using UnityEngine;

public class CheckForObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameEvents.Instance.OnGameFinished_Invoke(false);
        }
    }
}