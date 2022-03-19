using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed=2f;
    [SerializeField] private GameObject toPoint;

    private GameObject bird;
    private Animator anim;
    private bool stop=false;
    // Start is called before the first frame update
    void Start(){
        bird=GetComponent<GameObject>();
        anim=GetComponent<Animator>();
        if(transform.position.x<toPoint.transform.position.x) GetComponent<SpriteRenderer>().flipX=true;
        else GetComponent<SpriteRenderer>().flipX=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.transform.position)<2f||stop==true){
          anim.SetTrigger("fly");
            stop=true;
            transform.position=Vector2.MoveTowards(transform.position,toPoint.transform.position,Time.deltaTime*speed);
            if(Vector2.Distance(transform.position,toPoint.transform.position)==0.1f) 
                Destroy(bird);
        }
    
    }
}
