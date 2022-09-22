using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    [SerializeField]private LineRenderer lineRenderer;
    private List<Vector3> points;
    [SerializeField]private float lineUpdateDistance;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void UpdateLine(Vector2 position)
    {
        UpdateLine(new Vector3(position.x, position.y, 0));
    }

    public void UpdateLine(Vector3 position)
    {
        if (points == null)
        {
            points = new List<Vector3>();
            SetPoint(position);
            return;
        }

        if (Vector3.Distance(points[points.Count - 1], position) > lineUpdateDistance)
        {
            SetPoint(position);
        }
    }

    private void SetPoint(Vector2 point)
    {
        SetPoint(new Vector3(point.x, point.y, 0));
    }

    private void SetPoint(Vector3 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
}