
using UnityEngine;

public class Effects : MonoBehaviour
{
    private static Effects _i;
    public static Effects i {
       get {
            if (_i == null) _i = Instantiate(Resources.Load<Effects>("soundEffect"));
            return _i;
        }
       
    }
    
    public SoundAudioClip[] soundAudioClipsArray;
 
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManagers.Sound sound;
        public AudioClip audioClip;
    }
    
   
}
