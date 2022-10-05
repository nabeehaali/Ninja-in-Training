using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem flash;
    
    // Start is called before the first frame update
    void Start()
    {
        flash.Stop();
        //flash.Stop();
        StartCoroutine(show());
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            //StartCoroutine(flashStar());
            //play particle system
            //flash.Play();
            Instantiate(flash, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            //destroy gameObject
            Destroy(this.gameObject);

        }
    }

    IEnumerator show()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
