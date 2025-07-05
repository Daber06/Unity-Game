using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCamScript : MonoBehaviour
{

    public Camera introCam;
    public Camera mainCam;
    public Canvas introCanvas;

    // Start is called before the first frame update
    void Start()
    {
        introCam.enabled = true;
        mainCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (introCam.enabled)
        introCam.transform.position += introCam.transform.forward * 2f * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.C))
        {
            introCam.enabled = false;
            mainCam.enabled = true;
            introCanvas.gameObject.SetActive(false);
        }
    }
}
