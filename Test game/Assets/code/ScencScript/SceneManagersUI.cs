using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagersUI : MonoBehaviour
{
  [SerializeField]public GameObject menuUI;
  [SerializeField]public GameObject mainCammera;
  [SerializeField]public GameObject puzzleCammera;
  [SerializeField] private GameObject itemTxt;
  private bool playerDectected;
  private bool gameLoaded;
  
  private List<AsyncOperation> scenceToLoad = new List<AsyncOperation>();

  public void HideUserInterface()
  {
    menuUI.SetActive(true);
    playerDectected = false;
  }

  public void Start()
  {
    HideUserInterface();
  }

  public void Update()
  {
   
    if (playerDectected)
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        menuUI.SetActive(false);
        playerDectected = false;
        scenceToLoad.Add(SceneManager.LoadSceneAsync("JigsawPuzzle",LoadSceneMode.Additive));
        Debug.Log("GetPuzzle");
        gameLoaded = true;
      }
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      //  SceneManager.LoadScene("MainGame");
      SceneManager.UnloadSceneAsync("JigsawPuzzle");
      menuUI.SetActive(true);
      gameLoaded = false;
    }

    ChangeCam();
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      playerDectected = true;
      itemTxt.SetActive(true);
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      playerDectected = false;
      itemTxt.SetActive(false);
    }
  }

  /*void LoadScene()
  {
    SceneManager.LoadSceneAsync(gameObject.name);
    isLoaded = true;
  }

  void UnLoadScene()
  {
    if (isLoaded)
    {
      SceneManager.UnloadSceneAsync(gameObject.name);
      isLoaded = false;
    }
    
  }*/
  private void ChangeCam()
  {
    if (gameLoaded == true)
    {
      mainCammera.SetActive(false);
      puzzleCammera.SetActive(true);
    }
    else
    {
      mainCammera.SetActive(true);
      puzzleCammera.SetActive(false);
      
    }
  }
}
