using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetmousePos(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos) > 0.1f)
        {
            SetmousePos(mousePos);
        }

    }

    void SetmousePos(Vector2 mousePos)
    {
        points.Add(mousePos);

        lineRenderer.numPositions = points.Count;
        lineRenderer.SetPosition(points.Count - 1, mousePos);

        if (points.Count > 1)
            edgeCol.points = points.ToArray();
    }
}
