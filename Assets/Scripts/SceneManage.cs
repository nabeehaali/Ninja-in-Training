using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject player;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerMovement.gameOver == true)
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Countdown");
    }

}