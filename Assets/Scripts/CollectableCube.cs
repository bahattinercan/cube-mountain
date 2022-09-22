using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    private bool isCollected = false;
    private int index;

    public bool IsCollected()
    {
        return isCollected;
    }

    public void SetCollected(bool isCollected)
    {
        this.isCollected = isCollected;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            transform.SetParent(null);
            GetComponent<Collider>().enabled = false;
            InvokeRepeating("PlayerFall", .1f, .02f);
            GameEvents.Instance.OnLoseCube_Invoke();
        }
    }

    private void PlayerFall()
    {
        if (!Collector.instance.IsOnTheObstacle())
        {
            CancelInvoke("PlayerFall");
            Collector.instance.Height--;
            GameEvents.Instance.OnPlayerLanding_Invoke();
            Invoke("DeactiveGO", .25f);
        }
    }

    private void DeactiveGO()
    {
        gameObject.SetActive(false);
    }
}