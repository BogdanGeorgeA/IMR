using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactusBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(Camera.main.transform.position, transform.position) <= 0.5)
        {
            GetComponent<Animator>().SetBool("cameraClose", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("cameraClose", false);
        }
    }
}
