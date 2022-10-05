using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject obstaclePrefab;
    float numObstacles;
    public int min;
    public int max;
    float randPos;
    //Vector2 location;

    public GameObject leaves_fx;

    // Start is called before the first frame update
    void Start()
    {
        min = 2;
        max = 4;
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    IEnumerator spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            numObstacles = Random.Range(min, max);
            //location = new Vector2(Random.Range(-8, 8), 7);
            //Debug.Log(numObstacles);
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < numObstacles; i++)
            {
                randPos = Random.Range(-8.4f, 8.4f);
               Instantiate(obstaclePrefab, new Vector2(randPos, Random.Range(5, 9)), Quaternion.identity);
                Instantiate(leaves_fx, new Vector2(randPos, 4), Quaternion.identity);
                //transform.Rotate(0, 0, 360 * Time.deltaTime);
            }
            //Debug.Log("I am being spawned");
            
        }
        
    }
}
