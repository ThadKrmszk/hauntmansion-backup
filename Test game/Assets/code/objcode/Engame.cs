using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engame : MonoBehaviour
{
    [SerializeField] GameObject keyTxt;
    [SerializeField] GameObject falseExit;
    private bool playerDectected;

    public static bool canExit;
    // Start is called before the first frame update
    void Start()
    {
        playerDectected = false;
        canExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDectected)
        {
            if (canExit)
            {
             if (Input.GetKeyDown(KeyCode.Space))
                         {
                             SceneManager.LoadScene("ExitRoom");
                             playerDectected = false;
                             Debug.Log("Getinside");
                             SoundManagers.Playsound(SoundManagers.Sound.DoorOpen);
                         }   
            }
            else
            {
                
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = true;
            
            if (canExit)
            {
               keyTxt.SetActive(true);  
            }
            else
            {
                falseExit.SetActive(true);
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = false;
            falseExit.SetActive(false);
            if (canExit)
            {
                keyTxt.SetActive(false);  
            }
        }
    }
}

