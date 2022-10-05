using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    //public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playing_sound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playing_sound()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Play();
    }
}
