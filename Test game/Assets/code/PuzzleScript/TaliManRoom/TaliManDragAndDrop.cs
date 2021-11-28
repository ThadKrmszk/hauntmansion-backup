using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TaliManDragAndDrop : MonoBehaviour
{
    public GameObject selectedPiece;
    private int oil = 1;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<TaliManPiceseScript>().inRightPosition)
                {
                 selectedPiece = hit.transform.gameObject;
                 selectedPiece.GetComponent<TaliManPiceseScript>().selected = true;
                 selectedPiece.GetComponent<SortingGroup>().sortingOrder = oil;
                 oil++;
                }
                
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {
              selectedPiece.GetComponent<TaliManPiceseScript>().selected = false;
              selectedPiece = null;  
            }
            
        }

        if (selectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }
    }
}
