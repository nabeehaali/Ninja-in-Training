using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManageTitle : MonoBehaviour
{
    public GameObject shuriken;
    public AudioSource game_music;

    private void Start()
    {
        shuriken.GetComponent<Animator>().enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            game_music.Stop();
            StartCoroutine(changeScene());
            //shuriken.GetComponent<Animator>().enabled = true;
            //ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Onboarding");
    }

    IEnumerator changeScene()
    {
        shuriken.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.5f);
        ChangeScene();
    }
}
