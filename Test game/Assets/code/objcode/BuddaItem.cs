using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddaItem : MonoBehaviour
{
    public static bool haveABuddaItem;

    [SerializeField] public GameObject buddaItemUi;
    // Start is called before the first frame update
    void Start()
    {
        haveABuddaItem = false;
        buddaItemUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (haveABuddaItem)
        {
            buddaItemUi.SetActive(true);
            
           
        
        }
        else
        {
            buddaItemUi.SetActive(false);
        }

        if (Input.GetKey(KeyCode.K))
        {
            haveABuddaItem = true;
        }
    }
}
