using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class groundCollision : MonoBehaviour
{
    public GameObject shuriken_fx;
    bool isRotate;

    [SerializeField] GameObject starIgnore;
    // Start is called before the first frame update
    void Start()
    {
        isRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate == true)
        {
            transform.Rotate(new Vector3(0f, 0f, 1200f) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isRotate = false;
            Instantiate(shuriken_fx, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.2f, this.gameObject.transform.position.z), Quaternion.identity);
            StartCoroutine(destroy());
        }
        else if (collision.gameObject.tag == "Player")
        {
            isRotate = false;
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        //Debug.Log("I am being destroyed!");
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
        //Destroy(shuriken_fx);
    }
}
