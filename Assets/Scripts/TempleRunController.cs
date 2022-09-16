using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleRunController : MonoBehaviour
{
    public GameObject bala;
    public float velocity = 20;
    public float fuerzaSalto = 25;

    private GameManagerController gameManager;
    public AudioClip jumpClip;
    public AudioClip recogerClip;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    AudioSource audioSource;

    //bool vida = true;
    
    const int ANIMATION_IDLE = 0;
    const int ANIMATION_RUN = 1;
    const int ANIMATION_JUMP = 2;
    //const int ANIMATION_SLIDE = 3;
    //const int ANIMATION_DEATH = 4;

    void Start()
    {       
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>(); 
        animator = GetComponent<Animator>(); 
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManagerController>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y); 
        ChangeAnimation(ANIMATION_IDLE); 
        if(Input.GetKey(KeyCode.RightArrow)) 
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false; 
            ChangeAnimation(ANIMATION_RUN);
        }
        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y); 
            sr.flipX = true;
            ChangeAnimation(ANIMATION_RUN); 
        } 
        if(Input.GetKeyUp(KeyCode.Space)){      
            ChangeAnimation(ANIMATION_JUMP);    
            Saltar();  
            audioSource.PlayOneShot(jumpClip);
        }        

        //Para disparar
        if(sr.flipX == false && Input.GetKeyUp(KeyCode.C)){ 
            var balaPosition = transform.position +  new Vector3(3, 0, 0);
            var gb = Instantiate(bala, balaPosition, Quaternion.identity) as GameObject;
            var controller = gb.GetComponent<BalaController>();
            controller.SetRightDirection();
        }
        if(sr.flipX == true && Input.GetKeyUp(KeyCode.C)){ 
            var balaPosition = transform.position +  new Vector3(-3, 0, 0);
            var gb = Instantiate(bala, balaPosition, Quaternion.identity) as GameObject;
            var controller = gb.GetComponent<BalaController>();
            controller.SetLeftDirection();
        }
    }

    void Saltar(){
        rb.AddForce(new Vector2(0,fuerzaSalto), ForceMode2D.Impulse);
    }
    
    void ChangeAnimation(int animation){
        animator.SetInteger("Estado", animation);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Plata")
        {
            gameManager.monedasTipoPlata(10);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(recogerClip);
        }
        if(other.gameObject.tag == "Oro")
        {
            gameManager.monedasTipoOro(20);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(recogerClip);
        }
        gameManager.SaveGame();
    }
}
