using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count : MonoBehaviour
{
    public static int puzzleCount;
    [SerializeField] private GameObject tasksus;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("count"+puzzleCount);
        if (puzzleCount == 36)
        {
            MapOpen.haveAMap = true;
            Debug.Log("U got map");
            GameObjective.isGetAMap = true;
            tasksus.SetActive(true);
            SoundManagers.Playsound(SoundManagers.Sound.Healing);
            
        }
    }
}
