using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManagerController : MonoBehaviour
{
   public Text scoreText;
    public Text plataText;
    public Text oroText;

    private int score;
    private int plata;
    private int oro;

    void Start()
    {
        score = 0;
        plata = 0;
        oro = 0;
        printScoreInScreen();
        printPlataInScreen();
        printOroInScreen();
        LoadGame();
    }
    public void SaveGame(){ 
        var filePath = Application.persistentDataPath + "/fabian.dat";

        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenWrite(filePath);
        }else{
            file = File.Create(filePath);
        }

        GameData data = new GameData();
        data.Score=score;
        data.Plata=plata;
        data.Oro = oro;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame(){
        var filePath = Application.persistentDataPath + "/fabian.dat";

        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }else{
            Debug.LogError("No se encontró archivo");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();
        score = data.Score;
        plata = data.Plata;
        oro = data.Oro;
        printScoreInScreen();
        printPlataInScreen();
        printOroInScreen();
    }

    //ruta de guardado C:\Users\fabia\AppData\LocalLow\DefaultCompany*/

    public int Score(){
        return score;
    }

    public int Plata(){
        return plata;
    }
    public int Oro(){
        return oro;
    }

    public void ganarPuntos(int Puntos){
        score += Puntos;
        printScoreInScreen();
    }
    
    public void monedasTipoPlata(int Plata){
        plata += Plata;
        printPlataInScreen();
    }
    public void monedasTipoOro(int Oro){
        oro += Oro;
        printOroInScreen();
    }

    private void printScoreInScreen(){
        scoreText.text = "Score: " + score;
    }
    private void printPlataInScreen(){
        plataText.text = "Plata: " + plata;
    }
    private void printOroInScreen(){
        oroText.text = "Oro: " + oro;
    }
}

