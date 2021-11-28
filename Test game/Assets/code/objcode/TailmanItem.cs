using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailmanItem : MonoBehaviour
{
    public static bool haveATailmanItem;

    [SerializeField] public GameObject tailmanItemUi;
    // Start is called before the first frame update
    void Start()
    {
        haveATailmanItem = false;
        tailmanItemUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (haveATailmanItem)
        {
            tailmanItemUi.SetActive(true);
            
           
        
        }
        else
        {
            tailmanItemUi.SetActive(false);
        }

        if (Input.GetKey(KeyCode.K))
        {
            haveATailmanItem = true;
        }
    }
}
