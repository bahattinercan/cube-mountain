using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    LineDraw activeLine;
    Camera mainCamera;
    Vector2 mousePos;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // start paint
        if (Input.GetMouseButtonDown(0))
        {
            StartPainting();
        }
        // end paint
        if (Input.GetMouseButtonUp(0))
        {
            StopPainting();
        }

        if (activeLine != null)
        {
            ContinuePainting();
        }
    }

    private void StartPainting()
    {
        GameObject newLine = Instantiate(linePrefab);
        activeLine = newLine.GetComponent<LineDraw>();
    }

    private void StopPainting()
    {
        activeLine = null;
    }

    private void ContinuePainting()
    {
        Vector3 tempPos = Input.mousePosition;
        tempPos.z = mainCamera.nearClipPlane + 1;
        mousePos = mainCamera.ScreenToWorldPoint(tempPos);
        activeLine.UpdateLine(mousePos);
    }

}