using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private SpriteRenderer sprite;

     private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f){
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        if(transform.position.x>waypoints[currentWaypointIndex].transform.position.x){
            sprite.flipX = false;
        }else {
            sprite.flipX = true;
        }
    }


}
