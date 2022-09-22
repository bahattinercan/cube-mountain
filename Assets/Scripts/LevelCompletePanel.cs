using TMPro;
using UnityEngine;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.text = GameManager.instance.Level.ToString();
    }
}