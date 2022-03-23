
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bananas = 0;
    [SerializeField] private Text bananasText;
    [SerializeField] private AudioSource collectSound;


 private void OnTriggerEnter2D(Collider2D collision){
     if(collision.gameObject.CompareTag("banana")){
         Destroy(collision.gameObject);
         bananas++;
         if(PlayerPrefs.GetInt("Sound")==1)collectSound.Play();
         bananasText.text = "Fruits: " + bananas;
     }
 }
}
