using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayCount : MonoBehaviour
{
    [SerializeField] private GameObject tasksus;
    
    public static int prayCount;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("count"+prayCount);
        if (prayCount == 1)
        {
            TailmanItem.haveATailmanItem = true;
            BuddaItem.haveABuddaItem = false;
            GameObjective.isFindABuddha = true;
            tasksus.SetActive(true);
            Ghostdespawn.isGhostdespawn = true;
            
            SoundManagers.Playsound(SoundManagers.Sound.Healing);
        }
    }
}
