using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using VRTK;

public class trail : MonoBehaviour
{
    private VRTK_InteractableObject grabbedChalk;
    private GameObject currentLineRenderer;
    private VRTK_InteractableObject chalk;
    public GameObject lineRendererPrefab;
    private bool onDraw;
    private int numberOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        chalk = GetComponentInParent<VRTK_InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(",") && chalk.IsGrabbed())
        {
            DrawLine();
            onDraw = true;
        }
        else if (onDraw && chalk.IsGrabbed())
        {
            DrawLine();
        }

        if (Input.GetKeyUp(",") || !chalk.IsGrabbed())
        {
            onDraw = false;
            currentLineRenderer = null;
            numberOfPoints = 0;
        }
    }

    private void DrawLine()
    {

        if (currentLineRenderer == null)
        {
            currentLineRenderer = Instantiate(lineRendererPrefab) as GameObject;
        }

        numberOfPoints++;
        Vector3 wantedPos = chalk.transform.position;
        LineRenderer ln = currentLineRenderer.GetComponent<LineRenderer>();

        ln.positionCount = numberOfPoints;
        ln.SetPosition(numberOfPoints - 1, wantedPos);
    
    }
}
