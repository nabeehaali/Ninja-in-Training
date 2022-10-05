using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class step1 : MonoBehaviour
{
    public GameObject player;
    public Vector3 direction = new Vector3(1, 0, 0);
    public int speed = 4;

    [SerializeField]
    RuntimeAnimatorController O_L, O_R;

    TutorialManager skillBar;
    [SerializeField] GameObject empty;
    // Start is called before the first frame update
    void Start()
    {
        skillBar = empty.GetComponent<TutorialManager>();

        if (Random.value < 0.5f)
        {
            direction.x = -1;
            //movementAnim.runtimeAnimatorController = Resources.Load("Assets/Animation/Player_L.controller") as RuntimeAnimatorController;
            //movementAnim.SetBool("Left", true);
            this.GetComponent<Animator>().runtimeAnimatorController = O_L;
        }
        else
        {
            direction.x = 1;
            //movementAnim.runtimeAnimatorController = Resources.Load("Assets/Animation/Player.controller") as RuntimeAnimatorController;
            //movementAnim.SetBool("Right", true);
            this.GetComponent<Animator>().runtimeAnimatorController = O_R;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //moving player according to speed
        player.transform.Translate(direction * Time.deltaTime * speed);
        if (direction.x == 1)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = O_R;
            this.GetComponent<Animator>().speed = 1;
        }
        else if (direction.x == -1)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = O_L;
            this.GetComponent<Animator>().speed = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //change player direction if they hit a wall
        if (collision.gameObject.tag == "wall")
        {
            direction.x *= -1;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            skillBar.duration += 2f;
        }
        if (collision.gameObject.tag == "collect")
        {
            skillBar.duration -= 5f;
        }

    }

}
