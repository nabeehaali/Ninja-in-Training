using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnim : MonoBehaviour
{
    private Animator anim;

    PlayerMovement playermovement;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playermovement = player.GetComponent<PlayerMovement>();

        anim = gameObject.GetComponent<Animator>();
        anim.enabled = false;
    }

    private void Update()
    {
        if (playermovement.speed == 4)
        {
            anim.speed = 1;
        }
        else if (playermovement.speed == 6)
        {
            anim.speed = 2;
        }
        else if (playermovement.speed == 8)
        {
            anim.speed = 3;
        }
        else if (playermovement.speed >= 12)
        {
            anim.speed = 4;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("THis works!");
            anim.enabled = true;
            anim.Play("Tree_L", 0, 0f);
        }
    }

}
