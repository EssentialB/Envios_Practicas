using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public float velocity = 5;

    const int ANIMATION_WALK = 0;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-10, rb.velocity.y); 
        ChangeAnimation(ANIMATION_WALK);
    }

    void ChangeAnimation(int animation){
        animator.SetInteger("Estado", animation);
    }
    
}
