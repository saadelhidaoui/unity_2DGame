using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private AudioSource finishSound;
  
    private bool levelCompleted = false;
    


    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
      
      
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "player" && !levelCompleted){
            if(PlayerPrefs.GetInt("Sound")==1)finishSound.Play();
            levelCompleted = true;

            //set the Last Level reach 
            int level = SceneManager.GetActiveScene().buildIndex;

            if ( PlayerPrefs.GetInt("MaxLevel") <=level)
                PlayerPrefs.SetInt("MaxLevel", level+1);
            //wait 2 seconds to go to next level 

            Invoke("LevelComplet", 2f);
            

            
        }

    }

    private void LevelComplet(){
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel >= 11) nextLevel = 14;
        SceneManager.LoadScene(nextLevel);
       
    }
    

}
