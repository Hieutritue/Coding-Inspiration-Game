using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] GameObject firstPersonCam;
    [SerializeField] GameObject thirdPersonCam;
    public int camMode;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (camMode == 1)
            {
                camMode = 0;
            }
            else 
            {
                camMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (camMode == 0)
        {
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
        }
        else
        {
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
    }
}
