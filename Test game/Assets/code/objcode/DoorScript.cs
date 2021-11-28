using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    [SerializeField] GameObject keyTxt;
    private bool playerDectected;
    private GameObject PlayerGo;
    
    // Start is called before the first frame update
    void Start()
    {
        playerDectected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDectected)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerGo.transform.position = posToGo.position;
                playerDectected = false;
                Debug.Log("Getinside");
                SoundManagers.Playsound(SoundManagers.Sound.DoorOpen);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = true;
            PlayerGo = collision.gameObject;
            keyTxt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = false;
            keyTxt.SetActive(false);
        }
    }
}
