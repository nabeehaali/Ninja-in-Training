using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawn : MonoBehaviour
{
    public GameObject starPrefab;
    //private GameObject star;

    //public GameObject shurikenIgnore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        //Physics2D.IgnoreCollision(starPrefab.GetComponent<Collider2D>(), shurikenIgnore.GetComponent<Collider2D>());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Instantiate(starPrefab, new Vector2(0, -2.76f), Quaternion.identity);
            
            //star.transform.SetParent(this.gameObject.transform);
        }

    }
}
