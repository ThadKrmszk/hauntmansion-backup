using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private int maxHealth = 100;
    public static int currentHealth;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static HealthBar instance;

    private void Awake()
    {
        instance = this; 
    }
    
    void Start()
    {
     
        currentHealth = maxHealth;
       healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void Takedamage(int amount)
    {
        if (currentHealth - amount >= 0)
        {
            currentHealth -= amount;
            healthBar.value = currentHealth;
            if (regen != null) 
                
                StopCoroutine(regen);

            regen = StartCoroutine(RegenHealth());
        }
        else
        {
            Debug.Log("Your Dead");
        }
    }

    

    private IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(3);

        while (currentHealth < maxHealth )
        {
           // currentHealth += maxHealth / 50;
            healthBar.value = currentHealth;
            yield return regenTick;
        }

        regen = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            HealthBar.instance.Takedamage(50);
        }
        healthBar.value = currentHealth;
    }
}
