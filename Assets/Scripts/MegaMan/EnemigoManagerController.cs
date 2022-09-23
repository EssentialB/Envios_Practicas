using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class EnemigoManagerController : MonoBehaviour
{
    public Text liveText;

    private int lives;
    void Start()
    {
        lives = 3;
        printLivesInScreen();
        printLivesInScreenBala2();
        printLivesInScreenBala3();
    }

        
    public int Lives(){
        return lives;
    }
    public void perderVida(){
        lives -= 1;
        printLivesInScreen();
    }
    public void perderVidaBala2(){
        lives -= 2;
        printLivesInScreenBala2();
    }
    public void perderVidaBala3(){
        lives -= 3;
        printLivesInScreenBala3();
    }
    private void printLivesInScreen(){
        liveText.text = "Vidas del enemigo: " + lives;
    }
    private void printLivesInScreenBala2(){
        liveText.text = "Vidas del enemigo: " + lives;
    }
    private void printLivesInScreenBala3(){
        liveText.text = "Vidas del enemigo: " + lives;
    }
}
