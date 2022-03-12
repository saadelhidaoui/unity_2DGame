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
            finishSound.Play();
            levelCompleted = true;
            
            //wait 2 seconds to go to next level 
            Invoke("LevelComplet", 2f);


        }

    }

    private void LevelComplet(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
