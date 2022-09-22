using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            GameManager.instance.IsPassedFinishLine = true;
            Movement movement = GameManager.instance.player.GetComponent<Movement>();
            movement.IleriGitmeHizi = movement.IleriGitmeHizi * 2;
        }
    }
}