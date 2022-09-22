using TMPro;
using UnityEngine;

public class NextLevelPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI multiplierText;
    [SerializeField] private TextMeshProUGUI currentGemText;

    public void NextLevelButton()
    {
        GameManager.instance.LoadNextLevel();
    }

    private void OnEnable()
    {
        multiplierText.text = GameManager.instance.GemMultiplier + "X";
        currentGemText.text = GameManager.instance.GemMultiplier * GameManager.instance.RoundGem + "";
    }
}