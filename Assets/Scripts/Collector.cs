using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameObject mainCube;
    private int height;
    public static Collector instance;
    [SerializeField] private bool onTheObstacle;
    private int hittedObstacleNumber;
    [SerializeField] private Transform cameraTarget;
    private float cameraTargetHeight;

    // bottom painting
    private LineGeneratorForPlayer lineGeneratorForPlayer;

    public int Height { get => height; set => height = value; }
    public float CameraTargetHeight { get => cameraTargetHeight; set => cameraTargetHeight = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CameraTargetHeight = 0;
        onTheObstacle = false;
        hittedObstacleNumber = 0;
        lineGeneratorForPlayer = GameObject.Find("LineGenerator").GetComponent<LineGeneratorForPlayer>();
    }

    private void Update()
    {
        mainCube.transform.position = new Vector3(mainCube.transform.position.x, Height + 1, mainCube.transform.position.z);
        transform.localPosition = new Vector3(0, -Height, 0);
        cameraTarget.localPosition = new Vector3(0, -Height + CameraTargetHeight, 0);
        if (hittedObstacleNumber >= 1)
            onTheObstacle = true;
        else
            onTheObstacle = false;

        if (!onTheObstacle)
        {
            if (!lineGeneratorForPlayer.isAlreadyPainting())
            {
                lineGeneratorForPlayer.StartPainting();
            }
        }
        else
        {
            if (lineGeneratorForPlayer.isAlreadyPainting())
            {
                lineGeneratorForPlayer.StopPainting();
            }
        }
            
    }

    public bool IsOnTheObstacle()
    {
        if (!onTheObstacle)
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") && other.GetComponent<CollectableCube>().IsCollected() == false)
        {
            Height++;
            other.GetComponent<CollectableCube>().SetCollected(true);
            other.GetComponent<CollectableCube>().SetIndex(Height);
            other.transform.SetParent(mainCube.transform);
            other.transform.localPosition = new Vector3(0, -Height, 0);
            GameEvents.Instance.OnCollectCube_Invoke();
        }
        else if (other.CompareTag("Obstacle"))
        {
            hittedObstacleNumber++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            hittedObstacleNumber--;
        }
    }
}