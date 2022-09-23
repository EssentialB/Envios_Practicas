using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundaBalaController : MonoBehaviour
{
    public float velocity = 50;

    Rigidbody2D rb;
    Animator animator;
    
    float realVelocity;

    const int ANIMATION_BALA2=0;

    public void SetRightDirection(){
        realVelocity = velocity;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        rb.velocity = new Vector2(realVelocity, 0);
        ChangeAnimationBullet(ANIMATION_BALA2);
    }

    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "Enemigo")
        {
            Destroy(this.gameObject);
        }
    }
    void ChangeAnimationBullet(int animation){
        animator.SetInteger("EstadoBala2", animation);
    }
}
