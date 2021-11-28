using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManagers : MonoBehaviour
{
    public enum Sound 
    {
        //playersound
        PlayerWalk,
        PlayerRun ,
        PlayerDead,
        PlayerOpenMap,
        PlayerCloseMap,
        PlayerScearch,
        PlayerHearth,
        PlayerExhausted,

        //ghostsound
        GhostWalk,
        GhostHit,
        GhostSound,
        GhostStartChase,
        BossSound,
        
        //Effect
        DoorOpen,
        Healing,
        
        //EnMusic
        EndMusic,
        EndMusic2,
        
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialized()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerWalk] = 0f;
        soundTimerDictionary[Sound.PlayerRun] = 0f;
        soundTimerDictionary[Sound.PlayerExhausted] = 0f;
        soundTimerDictionary[Sound.PlayerHearth] = 0f;
        
        
        soundTimerDictionary[Sound.GhostWalk] = 0f;

        soundTimerDictionary[Sound.Healing] = 0f;
    }

   
     public static void Playsound(Sound sound) 
     {
         if (CanPlaySound(sound))
         {
              GameObject soundGameObject = new GameObject("Sound");
              AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
              audioSource.PlayOneShot(GetAudioClip(sound)); 
              audioSource.clip = GetAudioClip(sound);
              audioSource.volume = 0.3f;
         }
      
     }

     private static bool CanPlaySound(Sound sound)
     {
         switch (sound)
         {
             default:
                 return true;
             case Sound.PlayerWalk:
                 if (soundTimerDictionary.ContainsKey(sound))
                 {
                     float lastTimePlayed = soundTimerDictionary[sound];
                     float playerMoveTimerMax = .45f;
                     if (lastTimePlayed + playerMoveTimerMax < Time.time)
                     {
                         soundTimerDictionary[sound] = Time.time;
                         return true;
                     }else {
                         return false;
                     }
                 }
                 else
                 {
                     return true;
                 }
             
             case Sound.PlayerRun:
                 if (soundTimerDictionary.ContainsKey(sound))
                 {
                     float lastTimePlayed = soundTimerDictionary[sound];
                     float playerRunTimerMax = .25f;
                     if (lastTimePlayed + playerRunTimerMax < Time.time)
                     {
                         soundTimerDictionary[sound] = Time.time;
                         return true;
                     }else {
                         return false;
                     }
                 }
                 else
                 {
                     return true;
                 }
             case Sound.PlayerExhausted:
                 if (soundTimerDictionary.ContainsKey(sound))
                 {
                     float lastTimePlayed = soundTimerDictionary[sound];
                     float playerEXTimerMax = 1f;
                     if (lastTimePlayed + playerEXTimerMax < Time.time)
                     {
                         soundTimerDictionary[sound] = Time.time;
                         return true;
                     }else {
                         return false;
                     }
                 }
                 else
                 {
                     return true;
                 }
             case Sound.PlayerHearth:
                 if (soundTimerDictionary.ContainsKey(sound))
                 {
                     float lastTimePlayed = soundTimerDictionary[sound];
                     float playerHearthTimerMax = 1f;
                     if (lastTimePlayed + playerHearthTimerMax < Time.time)
                     {
                         soundTimerDictionary[sound] = Time.time;
                         return true;
                     }else {
                         return false;
                     }
                 }
                 else
                 {
                     return true;
                 }
             case Sound.GhostWalk:
                 if (soundTimerDictionary.ContainsKey(sound))
                 {
                     float lastTimePlayed = soundTimerDictionary[sound];
                     float ghoststartchaseTimerMax = 0.4f;
                     if (lastTimePlayed + ghoststartchaseTimerMax < Time.time)
                     {
                         soundTimerDictionary[sound] = Time.time;
                         return true;
                     }else {
                         return false;
                     }
                 }
                 else
                 {
                     return true;
                 }
             case Sound.Healing:
                 if (soundTimerDictionary.ContainsKey(sound))
                 {
                     float lastTimePlayed = soundTimerDictionary[sound];
                     float ghoststartchaseTimerMax = 5f;
                     if (lastTimePlayed + ghoststartchaseTimerMax < Time.time)
                     {
                         soundTimerDictionary[sound] = Time.time;
                         return true;
                     }else {
                         return false;
                     }
                 }
                 else
                 {
                     return true;
                 }
                 //break;
         }
     }

     private static AudioClip GetAudioClip(Sound sound)
     {
         foreach (Effects.SoundAudioClip soundAudioClip in Effects.i.soundAudioClipsArray)
         {
             if (soundAudioClip.sound == sound)
             {
                 return soundAudioClip.audioClip;
             }
             
         }
         Debug.LogError("Sound"+sound+"not found");
         return null;
     }
}
