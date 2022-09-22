using UnityEngine;

public class LineGeneratorForPlayer : MonoBehaviour
{
    Transform player;
    private bool isPainting;
    public GameObject linePrefab;
    LineDraw activeLine;
    Camera mainCamera;
    Vector2 mousePos;

    private void Start()
    {
        mainCamera = Camera.main;
        player = GameManager.instance.player;
        isPainting = true;
        StartPainting();
    }

    private void Update()
    {        
        transform.position = new Vector3(player.position.x-.5f,transform.position.y, player.position.z);

        if (activeLine != null)
        {
            ContinuePainting();
        }
    }

    public bool isAlreadyPainting()
    {
        if (isPainting)
            return true;
        return false;
    }

    public void StartPainting()
    {
        isPainting = true;
        GameObject newLine = Instantiate(linePrefab);
        activeLine = newLine.GetComponent<LineDraw>();
    }

    public void StopPainting()
    {
        isPainting = false;
        activeLine = null;
    }

    private void ContinuePainting()
    {
        activeLine.UpdateLine(transform.position);
    }
}