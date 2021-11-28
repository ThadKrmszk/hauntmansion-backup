using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostdespawn : MonoBehaviour
{
    [SerializeField] private GameObject ghostSpawn;
    [SerializeField] private GameObject keyTxt;
    [SerializeField] private GameObject safe;
    public static bool isGhostdespawn;
    private bool playerDectected;
    public static bool isSafe;
    // Start is called before the first frame update
    void Start()
    {
        ghostSpawn.SetActive(true);
        isGhostdespawn = false;
        isSafe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGhostdespawn)
        {
            ghostSpawn.SetActive(false);
            isSafe = true;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = true;
            if (isSafe)
            {
                safe.SetActive(true);
            }
            else
            {
                keyTxt.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = false;
            keyTxt.SetActive(false);
            safe.SetActive(false);
            
        }
    }
}
