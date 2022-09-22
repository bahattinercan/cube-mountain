using UnityEngine;

public class MultiplierFinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            GameEvents.Instance.OnGameFinished_Invoke(true);
        }
    }
}