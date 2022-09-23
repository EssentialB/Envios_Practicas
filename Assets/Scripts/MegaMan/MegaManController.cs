using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaManController : MonoBehaviour
{
    public GameObject bala,bala2,bala3;
    public float velocity = 20;
    public float fuerzaSalto = 25;
    public float timeLeft = 0;
    public LayerMask capaSuelo;
    public int saltosMax = 1;


    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    BoxCollider2D boxCollaider; 
    
    const int ANIMATION_IDLE = 0;
    const int ANIMATION_RUN = 1;
    const int ANIMATION_JUMP = 2;
    const int ANIMATION_ATACK = 3;
    const int ANIMATION_CARGAR = 4;

    private int saltosRestantes;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>(); 
        animator = GetComponent<Animator>();
        boxCollaider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMax;
    }

    // Update is called once per frame
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
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0){ 
            rb.velocity = new Vector2(rb.velocity.x,0f);
            Saltar();
            ChangeAnimation(ANIMATION_JUMP);
            saltosRestantes--;
        } 
        if(EstaEnSuelo()){
            saltosRestantes = saltosMax;
        }        
        if(Input.GetKey(KeyCode.X) ){ 
            ChangeAnimation(ANIMATION_CARGAR);
            timeLeft += Time.deltaTime;                   
        }
        if(timeLeft < 2){
                if(sr.flipX == false &&Input.GetKeyUp(KeyCode.X)){
                var balaPosition = transform.position +  new Vector3(3, 0, 0);
                var gb = Instantiate(bala, balaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PrimeraBalaController>();
                controller.SetRightDirection();
                }
                if(sr.flipX == true &&Input.GetKeyUp(KeyCode.X)){
                var balaPosition = transform.position +  new Vector3(-3, 0, 0);
                var gb = Instantiate(bala, balaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PrimeraBalaController>();
                controller.SetLeftDirection();
                }
        }
        else if(timeLeft>3 && timeLeft<5){
                if(sr.flipX == false &&Input.GetKeyUp(KeyCode.X)){
                var balaPosition = transform.position +  new Vector3(3, 0, 0);
                var gb = Instantiate(bala2, balaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<SegundaBalaController>();
                controller.SetRightDirection();
                }
                if(sr.flipX == true &&Input.GetKeyUp(KeyCode.X)){
                var balaPosition = transform.position +  new Vector3(-3, 0, 0);
                var gb = Instantiate(bala2, balaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<SegundaBalaController>();
                controller.SetLeftDirection();
                }
        }else if(timeLeft>5){
                if(sr.flipX == false &&Input.GetKeyUp(KeyCode.X)){
                var balaPosition = transform.position +  new Vector3(3, 0, 0);
                var gb = Instantiate(bala3, balaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<TerceraBalaController>();
                controller.SetRightDirection();
                }
                if(sr.flipX == true &&Input.GetKeyUp(KeyCode.X)){
                var balaPosition = transform.position +  new Vector3(-3, 0, 0);
                var gb = Instantiate(bala3, balaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<TerceraBalaController>();
                controller.SetLeftDirection();
                }
        }
        if(Input.GetKeyUp(KeyCode.X)){
            timeLeft = 0;
        }
    }
    bool EstaEnSuelo(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollaider.bounds.center,new Vector2(boxCollaider.bounds.size.x , boxCollaider.bounds.size.y) ,0f,Vector2.down,0.2f,capaSuelo);
        return raycastHit.collider != null;
    }
    private void Saltar(){
        rb.AddForce(new Vector2(0,fuerzaSalto), ForceMode2D.Impulse);
    }
    private void ChangeAnimation(int animation){
        animator.SetInteger("Estado", animation);
    }   
    
}
