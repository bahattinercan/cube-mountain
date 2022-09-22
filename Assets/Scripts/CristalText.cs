using TMPro;
using UnityEngine;

public class CristalText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameManager.instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int obj)
    {
        text.text = obj.ToString();
    }
}