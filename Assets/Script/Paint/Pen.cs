using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public Transform tip_pos;
    public Material mat_drawing;
    public Material mat_tip;

    [Range(0.01f, 0.1f)]
    public float pen_width = 0.01f;
    public Color[] pen_colors;

    private LineRenderer curr_drawing;
    private List<Vector3> pos = new();
    private int index;
    private int curr_color;

    private void Start()
    {
        curr_color = 0;
        mat_tip.color = pen_colors[curr_color];
    }

    public void Draw()
    {
        if(curr_drawing == null)
        {
            index = 0;
            curr_drawing = new GameObject().AddComponent<LineRenderer>();
            curr_drawing.material = mat_drawing;
            curr_drawing.startColor = curr_drawing.endColor = pen_colors[curr_color];
            curr_drawing.startWidth = curr_drawing.endWidth = pen_width;
            curr_drawing.positionCount = 1;
            curr_drawing.SetPosition(0, tip_pos.transform.position);
        }
        else
        {
            var currentPos = curr_drawing.GetPosition(index);
            if(Vector3.Distance(currentPos, tip_pos.transform.position) > 0.01f)
            {
                index++;
                curr_drawing.positionCount = index + 1;
                curr_drawing.SetPosition(index, tip_pos.transform.position);
            }
        }
    }

    public void SwitchColor()
    {
        if(curr_color == pen_colors.Length - 1)
        {
            curr_color = 0;
        }
        else
        {
            curr_color++;
        }

        mat_tip.color = pen_colors[curr_color];
    }
}
