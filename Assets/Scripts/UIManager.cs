using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gemScorePanel;
    [SerializeField] private GameObject levelScorePanel;
    [SerializeField] private GameObject tryAgainPanel;
    [SerializeField] private GameObject nextLevelPanel;

    private void Start()
    {
        GameEvents.Instance.OnGameFinished += Instance_OnGameFinished;
    }

    private void Instance_OnGameFinished(bool obj)
    {
        gemScorePanel.SetActive(false);
        levelScorePanel.SetActive(false);
        if (obj || GameManager.instance.IsPassedFinishLine)
            nextLevelPanel.SetActive(true);
        else
            tryAgainPanel.SetActive(true);
    }
}