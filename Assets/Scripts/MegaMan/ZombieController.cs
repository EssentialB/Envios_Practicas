using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float velocity = 10;
    
    private EnemigoManagerController gameManager;

    const int ANIMATION_WALK = 0;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
        gameManager = FindObjectOfType<EnemigoManagerController>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-velocity, rb.velocity.y); 
        ChangeAnimation(ANIMATION_WALK);
    }

    void ChangeAnimation(int animation){
        animator.SetInteger("Estado", animation);
    }
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "Bala1")
        {
            gameManager.perderVida();   
            if(gameManager.Lives() <= 0){
                Destroy(this.gameObject);               
            }                           
        }
        if(other.gameObject.tag == "Bala2")
        {
            gameManager.perderVidaBala2();   
            if(gameManager.Lives() <= 0){
                Destroy(this.gameObject);               
            }                           
        }
        if(other.gameObject.tag == "Bala3")
        {
            gameManager.perderVidaBala3();   
            if(gameManager.Lives() <= 0){
                Destroy(this.gameObject);               
            }                           
        }
    }
         
}
