using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraBalaController : MonoBehaviour
{
    public float velocity = 50;

    Rigidbody2D rb;
    
    float realVelocity;

    public void SetRightDirection(){
        realVelocity = velocity;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        rb.velocity = new Vector2(realVelocity, 0);
    }

    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "Enemigo")
        {
            Destroy(this.gameObject);
        }
    }
}
