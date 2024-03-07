using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject RedEnemy;
    public GameObject BlueEnemy;
    public GameObject GreenEnemy;
    public GameObject YellowEnemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        Vector3 spawnPos = transform.position;
        for(int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                for(int j = 0; j < 10; j++)
                {
                    spawnPos.x += 1;
                    GameObject Red = Instantiate(RedEnemy, spawnPos, Quaternion.identity);
                    Red.GetComponent<Enemy>().points = 10F;
                }
            }
            if(i == 1)
            {
                Vector3 spawnPosOne = transform.position;
                spawnPosOne.x += 0.1f;
                spawnPosOne.y = transform.position.y - 1;
                for(int j = 0; j < 10; j++)
                {   
                    spawnPosOne.x += 1;
                    GameObject Blue = Instantiate(BlueEnemy, spawnPosOne, Quaternion.identity);
                    Blue.GetComponent<Enemy>().points = 7.5F;
                }
            }
            if(i == 2)
            {
                Vector3 spawnPosTwo = transform.position;
                spawnPosTwo.x += 0.15f;
                spawnPosTwo.y = transform.position.y - 2;
                for(int j = 0; j < 10; j++)
                {
                    spawnPosTwo.x += 1;
                    GameObject Green = Instantiate(GreenEnemy, spawnPosTwo, Quaternion.identity);
                    Green.GetComponent<Enemy>().points = 5F;
                }
            }
            if(i == 3)
            {
                spawnPos.x += 0.2f;
                Vector3 spawnPosThree = transform.position;
                spawnPosThree.x += 0.2f;
                spawnPosThree.y = transform.position.y - 3;
                for(int j = 0; j < 10; j++)
                {
                    spawnPosThree.x += 1;
                    GameObject Yellow = Instantiate(YellowEnemy, spawnPosThree, Quaternion.identity);
                    Yellow.GetComponent<Enemy>().points = 2.5F;
                }
            }
        }
    }
}
