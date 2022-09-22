using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePercentSlider : MonoBehaviour
{
    private Image imageSlider;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform startPoint;
    private Transform player;
    private float distancex;

    private void Start()
    {
        imageSlider = GetComponent<Image>();
        player = GameObject.FindWithTag("Player").transform;
        distancex = endPoint.position.x - startPoint.position.x;
    }

    private void Update()
    {
        imageSlider.fillAmount = player.position.x / distancex;
    }
}