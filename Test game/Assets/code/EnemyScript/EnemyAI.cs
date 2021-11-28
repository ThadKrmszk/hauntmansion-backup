using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    public float deSpawnTime ;
    public float attackRange;
    public float attackDelay;
    private float lastAttackTime;
    private Animator ghost;
    
    
  

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        ghost = GetComponent<Animator>();
        SpawnAI.spawnAllowed = false;
        
        
        
          
       


    }

    // Update is called once per frame
    void Update()
    {
        
        //distrance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
            StopCoroutine(waitForDeSpawn());
            SoundManagers.Playsound(SoundManagers.Sound.PlayerHearth);
            SoundManagers.Playsound(SoundManagers.Sound.GhostWalk);
            
            


        }
        else
        {
            StopChasingPlayer();
            StartCoroutine(waitForDeSpawn());
            
           
        }

        if (distToPlayer < attackRange)
        {
            if (Time.time > lastAttackTime + attackDelay)
            {
                lastAttackTime = Time.time;
                HealthBar.instance.Takedamage(10);
                ghost.Play("Is_Atk");
                SoundManagers.Playsound(SoundManagers.Sound.GhostHit);
            }
           
            
        }

        
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to the left
            rb2d.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            ghost.SetBool("Is_Run",true);
        }
        else //if (transform.position.x > player.position.x)
        {
            //enemy is to the right
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            ghost.SetBool("Is_Run",true);
        }
        
    }
    
    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
        ghost.SetBool("Is_Run",false);
        //rb2d.velocity = new Vector2(Random.Range(-20.0f,20.0f ), Random.Range(0, 0));
        agroRange = 10;
        
    }
    
    IEnumerator waitForDeSpawn()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(deSpawnTime);
            ghost.Play("ghostdie");
            
           // Destroy(this.gameObject ,5f);
           
           //SpawnAI.spawnAllowed = true;
           
        }
    }
}
