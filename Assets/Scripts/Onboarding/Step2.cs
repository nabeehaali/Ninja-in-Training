using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject leaves_fx;

    float randPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            //location = new Vector2(Random.Range(-8, 8), 7);
            //Debug.Log(numObstacles);
            
                randPos = Random.Range(-8.4f, 8.4f);
                Instantiate(obstaclePrefab, new Vector2(randPos, Random.Range(5, 9)), Quaternion.identity);
                Instantiate(leaves_fx, new Vector2(randPos, 4), Quaternion.identity);
                //transform.Rotate(0, 0, 360 * Time.deltaTime);
            
            //Debug.Log("I am being spawned");

        }

    }
}
