using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] int GoLevel=1;
     private  GameObject Music ;
     
   public  void Home(){
       Music=GameObject.FindWithTag("Music");
        Music.GetComponent<MusicClass>().StopMusic();

       Click();
       Invoke("Click",1.5f);
       SceneManager.LoadScene(0);
    }
    public void Restart(){
        Click();
        Invoke("Click",1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadLevel(){

        Music=GameObject.FindWithTag("Music");
        if( GoLevel>13||GoLevel<11)
        {
            Music.GetComponent<MusicClass>().StopMusic(); 
        }
        else{
                Music.GetComponent<MusicClass>().PlayMusic();
        }
        
         Click();
        Invoke("Click",1.5f);
        SceneManager.LoadScene(GoLevel);
    }


    public void loadMap(){
        Music=GameObject.FindWithTag("Music");
         Music.GetComponent<MusicClass>().PlayMusic(); 

        float go=(SceneManager.GetActiveScene().buildIndex-1)/5;
        GoLevel=(int) go;
        Click();
        Invoke("Click",1.5f);
        SceneManager.LoadScene(GoLevel+11);
    }

    private void Click(){
        clickSound.Play();
    }
    
}
