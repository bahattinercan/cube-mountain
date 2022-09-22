using UnityEngine;

public class Gem : MonoBehaviour
{
    private int point;

    private void Start()
    {
        int gemPoint = GameManager.instance.GemPoint;
        point = (int)Random.Range(gemPoint * .75f, gemPoint * 1.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            GameManager.instance.AddScore(point);
            Destroy(gameObject);
        }
    }
}