using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;


public class playercontroller : MonoBehaviour
{
    public GameObject hurtUi;
    public GameObject tiredUi;
    public float currentSpeed = 1f ;
    public float runSpeed = 1;
    public float lowSpeed = 1;
    public float defaultSpeed = 1;
    public float currentStamina;
    public float maxStamina ;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    [SerializeField] private Animator animator;
    
    private bool isRun;
    private bool isTired;
    private bool isWalk;

    private void Awake()
    {
        SoundManagers.Initialized();
    }


    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentStamina = maxStamina;
       
    }

     void Update()
     {
        
     }

    void FixedUpdate()
    {
        move();
        Staminasystem();
        Animator();




    }

    void move()
    {
        //movecharracter
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position = transform.position += new Vector3(horizontalInput * Time.deltaTime * currentSpeed,0);

       
       animator.SetFloat("Speed",Mathf.Abs(horizontalInput));

     
        
       
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
            Debug.Log("run");
        }
        
        else
        {
            currentSpeed = defaultSpeed;
        }
        Physics2D.IgnoreLayerCollision(3 ,7,true);
      
        
       
            
        
    }
    //AnimetionForPlayer
    void Animator()
    {
        if (currentSpeed == runSpeed)
        {
            animator.SetBool("is_Run",true);
            SoundManagers.Playsound(SoundManagers.Sound.PlayerRun);
        }
        else
        {
            animator.SetBool("is_Run",false);
            
        }

        if (HealthBar.currentHealth < 50  )
        { 
            animator.SetBool("is_Damage",true);
            hurtUi.SetActive(true);
            SoundManagers.Playsound(SoundManagers.Sound.PlayerHearth);

        }
        else
        { 
            animator.SetBool("is_Damage",false);
            hurtUi.SetActive(false);
        }
        
        
        
        
        if (HealthBar.currentHealth <= 0)
        {
            animator.Play("Mandie");
            defaultSpeed = 0;
            //SceneManager.LoadScene("GameOver");
            // Debug.Log("GameOver");
            
        }
        
        if (HealthBar.currentHealth >= 1)
        if (Input.GetKey(KeyCode.D)) 
        {
            _spriteRenderer.flipX = false;
          

        }
        
        else if (Input.GetKey(KeyCode.A)) 
        {
            _spriteRenderer.flipX = true;
          
        }
    }
    //MakePlayerToUseStamina
    void Staminasystem()
    {
        
        if (currentSpeed > defaultSpeed)
        {
            Usestamina(1);
            StaminaBar.instance.Usestamina(1);
        }
    }
    //StaminaSystem
    public void Usestamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            
            if (regen != null) 
                
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
            
        }
        else
        {
            
            currentSpeed = lowSpeed;
            Debug.Log("I can't Run");
            tiredUi.SetActive(true);
            
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 70;
            yield return regenTick;
            tiredUi.SetActive(false);
        }

        regen = null;
    }
}
