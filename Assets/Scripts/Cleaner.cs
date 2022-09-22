using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] private Material transparentMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && other.gameObject.layer == 0)
        {
            other.gameObject.SetActive(false);
        }
    }
}