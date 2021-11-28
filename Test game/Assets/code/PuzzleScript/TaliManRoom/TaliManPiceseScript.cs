using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class TaliManPiceseScript : MonoBehaviour
{
    public bool inRightPosition;
    public bool selected;
    private Vector3 rightPosition;
    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-53f, -40f), Random.Range(7f, -7f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,rightPosition) < 7.3f)
        {
            if (!selected)
            {
                if (inRightPosition == false)
                {
                   transform.position = rightPosition;
                   inRightPosition = true;
                   GetComponent<SortingGroup>().sortingOrder = 0;
                   TaliManCount.taliManCount ++;
                  
                }
            }
        }
    }
}
