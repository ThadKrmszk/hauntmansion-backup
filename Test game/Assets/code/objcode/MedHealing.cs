using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedHealing : MonoBehaviour
{
    public static bool haveAMed;

    [SerializeField] public GameObject medKitUi;
    // Start is called before the first frame update
    void Start()
    {
        haveAMed = false;
        medKitUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (haveAMed)
        {
            medKitUi.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                HealthBar.currentHealth += 100;
                if (HealthBar.currentHealth > 100)
                {
                    HealthBar.currentHealth = 100;
                }
                SoundManagers.Playsound(SoundManagers.Sound.Healing);

                haveAMed = false;
            }
        
        }
        else
        {
            medKitUi.SetActive(false);
        }

        if (Input.GetKey(KeyCode.K))
        {
            haveAMed = true;
        }
    }
}
