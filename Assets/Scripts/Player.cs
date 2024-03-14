using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
  public GameObject bullet;
  public GameObject activeObject;
  
  public float speed;
  public Transform shottingOffset;
    // Update is called once per frame
  public delegate void PlayerDied();
  public static event PlayerDied OnPlayerDied;

  void Start()
  {
    Enemy.OnEnemyDied += GetOnEnemyDied; 
  }

  void OnDestroy()
  {
    Enemy.OnEnemyDied -= GetOnEnemyDied;
  }
  void GetOnEnemyDied(float pointWorth)
    {
      Debug.Log($"Player received EnemyDied worth {pointWorth}");

    }
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      activeObject = GameObject.Find("Bullet(Clone)");
      if(activeObject == null){
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        Debug.Log("Bang!");

        Destroy(shot, 3f);
      }
    }
    if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -11)
    {
      transform.position += transform.right * -speed * Time.deltaTime;
    }
    if(Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 11)
    {
      transform.position += transform.right * speed * Time.deltaTime;
    }
  }
}
