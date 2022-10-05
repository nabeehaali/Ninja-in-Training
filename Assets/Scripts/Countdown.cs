using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public TMP_Text countdown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDown(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator countDown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            countdown.SetText("" + count);
            yield return new WaitForSeconds(1);
            count--;
        }

        SceneManager.LoadScene("MainGame");
    }
}
