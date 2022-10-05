using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBar : MonoBehaviour
{
    private Image skillBar;
    public float min = 0.05f;
    float max = 1;
    public float duration;
    float startTime;

    Color tempColor;

    [SerializeField] TextMeshProUGUI statusUI;
    [SerializeField] TextMeshProUGUI win;
    [SerializeField] TextMeshProUGUI click;
    //[SerializeField] Button restart;
    [SerializeField] GameObject confetti;

    [SerializeField] Animator cam_zoom;
    //[SerializeField] RuntimeAnimatorController secondCam;

    //ObstacleSpawn obstacleSpawn;
    //PlayerMovement playerMovement;
    //[SerializeField] GameObject player;
    //[SerializeField] GameObject block;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        skillBar = GetComponent<Image>();
        skillBar.fillAmount = min;
        startTime = Time.time;

        //restart.gameObject.SetActive(false);
        statusUI.text = "Beginner";
        confetti.SetActive(false);
        win.text = "";
        click.text = "";

        cam_zoom.enabled = false;

        //playerMovement = player.GetComponent<PlayerMovement>();
        //obstacleSpawn = block.GetComponent<ObstacleSpawn>();
        //set skill to 0
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        skillBar.fillAmount = Mathf.Lerp(min, max, t);

        if (skillBar.fillAmount > 0 && skillBar.fillAmount <= 0.33)
        {
            skillBar.color = Color.yellow;
            statusUI.text = "Beginner";
            //cam_zoom.enabled = true;
            //cam_zoom.Play("Cam_Slide", 0, 0f);
            //StartCoroutine(camAnim());

        }
        /*else if (skillBar.fillAmount == 0.33)
        {
            //camera zoom
            cam_zoom.enabled = true;
            cam_zoom.Play("Cam_Slide", 0, 0f);
        }*/
        else if (skillBar.fillAmount > 0.33 && skillBar.fillAmount <= 0.66)
        {
            skillBar.color = Color.green;
            statusUI.text = "Intermediate";
            //cam_zoom.runtimeAnimatorController = secondCam;
            //cam_zoom.Play("Cam_Slide2", 0, 0f);
            //cam_zoom.Play("Cam_Slide", 0, 0f);
            //cam_zoom.enabled = true;
            //cam_zoom.Play("Cam_Slide", 0, 0f);
            //StartCoroutine(camAnim());

        }
        /*else if (skillBar.fillAmount == 0.66)
        {
            //camera zoom
            cam_zoom.enabled = true;
            cam_zoom.Play("Cam_Slide", 0, 0f);
        }*/
        else if (skillBar.fillAmount > 0.66 && skillBar.fillAmount < 1)
        {
            skillBar.color = Color.blue;
            statusUI.text = "Advanced";
            //cam_zoom.enabled = true;
            //cam_zoom.Play("Cam_Slide", 0, 0f);
            //StartCoroutine(camAnim());
        }
        else if (skillBar.fillAmount == 1)
        {
            skillBar.color = Color.red;
            statusUI.text = "Master";
            win.text = "You Win!";
            click.text = "Click X to start over";
            confetti.SetActive(true);
            //restart.gameObject.SetActive(true);
        }

        if ((skillBar.fillAmount > 0.33 && skillBar.fillAmount < 0.35))
        {
            //cam_zoom.Play("Cam_Slide", 0, 0f);
            cam_zoom.enabled = true;
            StartCoroutine(camAnim());
            //Debug.Log("Here #1!!!!");
        }
        if ((skillBar.fillAmount > 0.63 && skillBar.fillAmount < 0.65))
        {
            cam_zoom.enabled = true;
            cam_zoom.Play("Cam_Slide", 0, 0f);
            //StartCoroutine(camAnim());
            //Debug.Log("Here #2!!!!");
        }
    }

    /*IEnumerator colourChange()
    {
        tempColor = skillBar.color;
        skillBar.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        skillBar.color = tempColor;
    }*/

    IEnumerator camAnim()
    {
        //cam_zoom.enabled = true;
        yield return new WaitForSeconds(1.2f);
        cam_zoom.enabled = false;
    }
}
