using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float dirX = 0f;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    // to edit the numbers in unity
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MouvementState{ idle, running, jumping, falling }


    [SerializeField] private AudioSource jumpSound;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //move right or left
        dirX = Input.GetAxisRaw("Horizontal");
        //if dirX < 0 it will move left and if dirX > 0 it will move right
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        //for the player to jump
        if(Input.GetButtonDown("Jump") && isGrounded()){
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
      
    }

    private void UpdateAnimation(){
        MouvementState state;
        //switch between animations while running or stopping
        if(dirX > 0f){
            state = MouvementState.running;
            sprite.flipX = false;
        }else if(dirX < 0f){
            state = MouvementState.running;
            sprite.flipX = true;
        }else{
            state = MouvementState.idle;
        }

        //switch between animations while jumping or falling
        if(rb.velocity.y > 0.1f){
            state = MouvementState.jumping;

        }else if(rb.velocity.y < -0.1f){
            state = MouvementState.falling;

        }

        anim.SetInteger("state", (int)state);
    }

    //is the player is on the ground
    private bool isGrounded(){
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f /* no rotation */, Vector2.down, 0.1f, jumpableGround);
    }

}
