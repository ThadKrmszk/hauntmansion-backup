using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPos : MonoBehaviour
{
    [SerializeField] public GameObject flashLight;
    [SerializeField] public Transform lightPosL;
    [SerializeField] public Transform lightPosR;
    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            flashLight.transform.position = lightPosR.position;
            
            transform.localScale = new Vector2(-6.237666f, 1.467927f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            flashLight.transform.position = lightPosL.position;
            
            transform.localScale = new Vector2(6.237666f, 1.467927f);
        }
    }
    
}
