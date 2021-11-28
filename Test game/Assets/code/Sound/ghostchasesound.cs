using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ghostchasesound : StateMachineBehaviour
{
    
    public static bool cheseplay = true;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cheseplay)
        {
          SoundManagers.Playsound(SoundManagers.Sound.GhostStartChase);   
        }

        cheseplay = false;

    }
    

   
}
