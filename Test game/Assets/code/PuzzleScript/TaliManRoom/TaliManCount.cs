using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaliManCount : MonoBehaviour
{
    [SerializeField] private GameObject tasksus;
    public static int taliManCount;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("count"+taliManCount);
        if (taliManCount == 1)
        {
            TailmanItem.haveATailmanItem = false;
            GameObjective.isFindABuddha = true;
            tasksus.SetActive(true);
            Engame.canExit = true;
            
            SoundManagers.Playsound(SoundManagers.Sound.Healing);
        }
    }
}
