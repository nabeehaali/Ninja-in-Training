using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] instructions;
    private int inst_index = 0;
    public GameObject player;

    step1 step;

    public GameObject obstaclePrefab;
    public GameObject leaves_fx;
    float randPos;

    public GameObject starPrefab;
    public Image skillBar;
    public float min = 0.05f;
    float max = 1;
    public float duration;
    float startTime;
    [SerializeField] TextMeshProUGUI statusUI;

    Coroutine lastRoutine = null;
    Coroutine lastRoutine2 = null;

    private void Start()
    {
        step = player.GetComponent<step1>();
        skillBar.fillAmount = min;
        //startTime = Time.time;

        //restart.gameObject.SetActive(false);
        statusUI.text = "Beginner";
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            if (i == inst_index)
            {
                instructions[i].SetActive(true);
            }
            else
            {
                instructions[i].SetActive(false);
            }
        }

        

        if (inst_index == 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                player.GetComponent<step1>().enabled = true;
                player.GetComponent<Animator>().enabled = true;
                
            }
        }
        else if (inst_index == 1)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                
                player.GetComponent<step1>().enabled = true;
                StartCoroutine(dash());
                //dash
            }
        }
        else if (inst_index == 2)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                
                player.GetComponent<step1>().enabled = false;
                player.GetComponent<Animator>().enabled = false;
                //hold
            }
        }
        else if (inst_index == 3)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                lastRoutine = StartCoroutine(spawn());
                player.GetComponent<step1>().enabled = true;
                player.GetComponent<Animator>().enabled = true;
                startTime = Time.time;
                //shuriken
            }
        }
        else if (inst_index == 4)
        {
            float t = (Time.time - startTime) / duration;
            skillBar.fillAmount = Mathf.Lerp(min, max, t);
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                StopCoroutine(lastRoutine);
                lastRoutine2 = StartCoroutine(spawncollect());
                player.GetComponent<step1>().enabled = true;
                //sai
            }
        }
        else if (inst_index == 5)
        {
            float t = (Time.time - startTime) / duration;
            skillBar.fillAmount = Mathf.Lerp(min, max, t);
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                StopCoroutine(lastRoutine2);
                player.GetComponent<step1>().enabled = true;
                //skillbar
            }
        }
        else if (inst_index == 6)
        {
            float t = (Time.time - startTime) / duration;
            skillBar.fillAmount = Mathf.Lerp(min, max, t);
            if (Input.GetKeyDown(KeyCode.X))
            {
                inst_index++;
                player.GetComponent<step1>().enabled = false;
                player.GetComponent<Animator>().enabled = false;
                //animate skillbar
            }
        }
        else if (inst_index == 7)
        {
            skillBar.fillAmount = 0.05f;
            //return player to the middle of the screen
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Countdown");
            }
        }



        if (skillBar.fillAmount > 0 && skillBar.fillAmount <= 0.33)
        {
            skillBar.color = Color.yellow;
            statusUI.text = "Beginner";
        }
        else if (skillBar.fillAmount > 0.33 && skillBar.fillAmount <= 0.66)
        {
            skillBar.color = Color.green;
            statusUI.text = "Intermediate";
        }
        else if (skillBar.fillAmount > 0.66 && skillBar.fillAmount < 1)
        {
            skillBar.color = Color.blue;
            statusUI.text = "Advanced";
        }
        else if (skillBar.fillAmount == 1)
        {
            skillBar.color = Color.red;
            statusUI.text = "Master";
        }
    }

    IEnumerator dash()
    {
        step.speed = 8;
        player.GetComponent<TrailRenderer>().emitting = true;
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<TrailRenderer>().emitting = false;
        step.speed = 4;
    }

    IEnumerator spawn()
    {
        while (true)
        {
            
            //location = new Vector2(Random.Range(-8, 8), 7);
            //Debug.Log(numObstacles);

            randPos = Random.Range(-8.4f, 8.4f);
            Instantiate(obstaclePrefab, new Vector2(randPos, Random.Range(5, 9)), Quaternion.identity);
            Instantiate(leaves_fx, new Vector2(randPos, 4), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            //transform.Rotate(0, 0, 360 * Time.deltaTime);

            //Debug.Log("I am being spawned");

        }

    }

    IEnumerator spawncollect()
    {
        while (true)
        {
            
            Instantiate(starPrefab, new Vector2(0, -2.76f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            //star.transform.SetParent(this.gameObject.transform);
        }

    }
}
