using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchItem : MonoBehaviour
{
    [SerializeField] GameObject noItem;
    [SerializeField] GameObject keyTxt;
    [SerializeField] GameObject gotMedTxt;
    private bool playerDectected;
    private bool isSearch;
    void Start()
    {
        playerDectected = false;
        isSearch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDectected)
        {
            if (isSearch == false)
            {
              if (Input.GetKeyDown(KeyCode.Space))
              {
                  playerDectected = false;
                  MedHealing.haveAMed = true;
                  Debug.Log("search");
                  SoundManagers.Playsound(SoundManagers.Sound.PlayerScearch);
                  gotMedTxt.SetActive(true);
                  isSearch = true;
                  keyTxt.SetActive(false);
              }  
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDectected = true;
            if (isSearch)
            {
                noItem.SetActive(true);
                
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
            gotMedTxt.SetActive(false);
            noItem.SetActive(false);
        }
    }
}