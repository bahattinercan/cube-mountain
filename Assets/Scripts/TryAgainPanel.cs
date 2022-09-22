using UnityEngine;

public class TryAgainPanel : MonoBehaviour
{
    public void RestartButton()
    {
        GameManager.instance.RestartLevel();
    }
}