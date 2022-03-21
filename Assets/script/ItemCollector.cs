using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bananas;
    [SerializeField] private Text bananasText;
    [SerializeField] private AudioSource collectSound;


 private void OnTriggerEnter2D(Collider2D collision){
     if(collision.gameObject.CompareTag("banana")){
         bananasText.text = "Fruits: " + bananas;
         Destroy(collision.gameObject);
         bananas++;
         collectSound.Play();
         bananasText.text = "Fruits: " + bananas;

     }
 }
}
