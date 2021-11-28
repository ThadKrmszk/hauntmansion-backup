using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    [SerializeField] public GameObject mainCam;
    [SerializeField] public Transform camPosL;
    [SerializeField] public Transform camPosR;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            mainCam.transform.position = camPosR.position;
            
           // transform.localScale = new Vector2(-6.237666f, 1.467927f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            mainCam.transform.position = camPosL.position;
            
            //transform.localScale = new Vector2(6.237666f, 1.467927f);
        }
    }

}
