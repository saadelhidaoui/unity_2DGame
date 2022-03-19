using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOn : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;
    void Start()
    {
        
        anim=GetComponent<Animator>();
        Invoke("TurnOn",4f);        
        Debug.Log("hello world");
    }
    private void TurnOn(){
        anim.SetTrigger("On");
    }
    
}
