using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  //TODO: Make enemies move side to side. 
  //TODO: Use the Speed variable to determine how quickly they move. Try broadcasting it!
  //TODO: Add barriers. Shouldn't be too hard, in theory. Don't need a parent since they don't come back between rounds.
  //TODO: Take it easy! Past Sable believes in you, and they don't want you being stressed out over this. ^-^
    public delegate void EnemyDied(float pointWorth);
    public static event EnemyDied OnEnemyDied;
    public delegate void EnemyMoving(int newDir);
    public static event EnemyMoving OnEnemyMoving;
    public float points = 10F;
    public float speed = 2.0F;
    public static bool justTurned = false;
    public float speedIncrement = 0.05F;
    public int moveDistance = 1;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag=="bullet"){
        Destroy(collision.gameObject);
        //speed = speed - speedIncrement;
        //Debug.Log($"Speed: {speed}");
        OnEnemyDied -= GetOnEnemyDied;
        OnEnemyMoving -= GetOnEnemyMoving;
        OnEnemyDied.Invoke(points);
        Destroy(this.gameObject);
      } 
      else
      {
        Destroy(collision.gameObject);
      }
      /*
      if(collision.gameObject.tag == "Left Boundary"){
        OnEnemyMoving.Invoke();
      }
      if(collision.gameObject.tag == "Right Boundary"){
        OnEnemyMoving.Invoke();
      }
      */
    }
    
    void Start()
    {
      OnEnemyDied += GetOnEnemyDied; //Change these, they don't work
      OnEnemyMoving += GetOnEnemyMoving;
      InvokeRepeating("Move", speed, speed);
    }
    void GetOnEnemyDied(float points)
    {
      speed -= speedIncrement;
      Debug.Log($"Speed: {speed}");
    }
    void GetOnEnemyMoving(int newDir)
    {
      moveDistance = moveDistance * newDir;
      transform.position += transform.right * moveDistance;
      transform.position += transform.up * -1; 
    }
    void Move()
    {
      //Vector3 temp = transform.position
      if(transform.position.x >= 11){
        OnEnemyMoving.Invoke(-1);
      }
      else if(transform.position.x <= -11){
        OnEnemyMoving.Invoke(-1);
      }
      else
      {
        transform.position += transform.right * moveDistance; 
      } 
    }
    
}
