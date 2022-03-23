using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource dyingSound;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //when player collide with traps he dies
    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("trap")){
           if(PlayerPrefs.GetInt("Sound")==1) dyingSound.Play();
            Die();
        }
    }
    //Player dies
    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    //player start level
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
