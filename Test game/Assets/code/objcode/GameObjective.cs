using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjective : MonoBehaviour
{
    [SerializeField] GameObject getAMap;
    [SerializeField] GameObject findABuddha;
    [SerializeField] GameObject getATalisman;
    
    [SerializeField] GameObject jigSawPuzzle;
    [SerializeField] GameObject prayPuzzle;
    [SerializeField] GameObject tailManPuzzle;

    public static bool isGetAMap;

    public static bool isFindABuddha;

    public static bool isGetATalisman;
    // Start is called before the first frame update
    void Start()
    {
        getAMap.SetActive(true);
        findABuddha.SetActive(false);
        getATalisman.SetActive(false);

        isGetAMap = false;
        isFindABuddha = false;
        isGetATalisman = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            isGetAMap = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isFindABuddha = true;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            isGetATalisman = true;
        }
        if (isGetAMap)
        {
            getAMap.SetActive(false);
            findABuddha.SetActive(true);
            jigSawPuzzle.SetActive(false);
            prayPuzzle.SetActive(true);
        }

        if (isFindABuddha)
        {
            prayPuzzle.SetActive(false);
            findABuddha.SetActive(false);
            getATalisman.SetActive(true);
            tailManPuzzle.SetActive(true);
        }

        if (isGetATalisman)
        {
          
        }

       
    }
}
