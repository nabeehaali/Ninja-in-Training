using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 direction = new Vector3(1, 0, 0);
    public float speed;
    public float maxSpeed;
    bool runUpdate;
    float OGSpeed;
    float dashSpeed;
    private TrailRenderer _trailRender;
    public bool gameOver;

    //[SerializeField] Animator cam_zoom;

    [SerializeField]
    RuntimeAnimatorController B_L, B_R, G_L, G_R, O_L, O_R;

    [SerializeField]
    GameObject l_eye, r_eye;

    //public RuntimeAnimatorController anim3;
    //public RuntimeAnimatorController anim4;

    //public AudioClip hitSFX;
    AudioSource hitSFX;
    public AudioSource steps;
    public AudioSource dash;


    SkillBar skillBar;
    [SerializeField] Image skill;

    ObstacleSpawn obstacleSpawn;
    [SerializeField] GameObject obstacle;

    [SerializeField] GameObject collection;

    //[SerializeField] ParticleSystem leaves_l;
    //[SerializeField] ParticleSystem leaves_r;

    [SerializeField] ParticleSystem blood;

    //[SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite end_l, end_r;
    //[SerializeField] Animator tree_l;
    //[SerializeField] Animator tree_r;

    void Start()
    {
        skillBar = skill.GetComponent<SkillBar>();
        obstacleSpawn = obstacle.GetComponent<ObstacleSpawn>();

        //spriteRenderer = GetComponent<SpriteRenderer>();
        //end_l = Resources.Load<Sprite>("Red_L");
        //end_r = Resources.Load<Sprite>("Red_R");

        runUpdate = true;
        maxSpeed = speed * 2;

        gameOver = false;

        hitSFX = GetComponent<AudioSource>();

        _trailRender = GetComponent<TrailRenderer>();

        //cam_zoom.enabled = false;

        //movementAnim = GetComponent<Animator>();

        //leaves_l.Stop();
        //leaves_r.Stop();

        blood.Stop();

        l_eye.SetActive(false);
        r_eye.SetActive(false);
        
        //randomize left or right direction
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

    void Update()
    {
        
        //checking various types of spacebar inputs
        if (Input.GetKey(KeyCode.X) == false)
        {
            steps.mute = false;
            //steps.Play();
            //moving player according to speed
            player.transform.Translate(direction * Time.deltaTime * speed);
            if (direction.x == 1)
            {
                if (skill.color == Color.yellow && runUpdate == true)
                {
                    //Debug.Log("it is blue");
                    speed = 4;
                    OGSpeed = 4;
                    maxSpeed = speed * 2;
                    dashSpeed = 0.5f;

                    obstacleSpawn.min = 1;
                    obstacleSpawn.max = 3;

                    this.GetComponent<Animator>().runtimeAnimatorController = O_R;
                    this.GetComponent<Animator>().speed = 1;

                    steps.pitch = 1;
                }
                else if (skill.color == Color.green && runUpdate == true)
                {
                    //Debug.Log("it is yellow");
                    speed = 6;
                    OGSpeed = 6;
                    maxSpeed = speed * 2;
                    dashSpeed = 0.4f;

                    obstacleSpawn.min = 3;
                    obstacleSpawn.max = 5;

                    this.GetComponent<Animator>().runtimeAnimatorController = G_R;
                    this.GetComponent<Animator>().speed = 1;

                    steps.pitch = 1.5f;

                }
                else if (skill.color == Color.blue && runUpdate == true)
                {
                    //Debug.Log("it is blue");
                    speed = 8;
                    OGSpeed = 8;
                    maxSpeed = speed * 2;
                    dashSpeed = 0.3f;

                    obstacleSpawn.min = 4;
                    obstacleSpawn.max = 6;

                    this.GetComponent<Animator>().runtimeAnimatorController = B_R;
                    this.GetComponent<Animator>().speed = 1;

                    steps.pitch = 2;
                }
                else if (skill.color == Color.red)
                {
                    //Debug.Log("it is magenta");
                    speed = 0;
                    Destroy(obstacle);
                    Destroy(collection);
                    this.GetComponent<Animator>().enabled = false;
                    //spriteRenderer.sprite = end_r;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = end_r;
                    gameOver = true;

                    steps.Stop();
                }
                //regular aniamtion
                //Debug.Log("Move right!");
                
                //movementAnim.runtimeAnimatorController = Resources.Load("Assets/Animation/Player.controller") as RuntimeAnimatorController;
            }
            else if (direction.x == -1)
            {
                if (skill.color == Color.yellow && runUpdate == true)
                {
                    //Debug.Log("it is blue");
                    speed = 4;
                    OGSpeed = 4;
                    maxSpeed = speed * 2;
                    dashSpeed = 0.5f;

                    obstacleSpawn.min = 1;
                    obstacleSpawn.max = 3;

                    this.GetComponent<Animator>().runtimeAnimatorController = O_L;
                    this.GetComponent<Animator>().speed = 1;

                    steps.pitch = 1;
                }
                else if (skill.color == Color.green && runUpdate == true)
                {
                    //Debug.Log("it is yellow");
                    speed = 6;
                    OGSpeed = 6;
                    maxSpeed = speed * 2;
                    dashSpeed = 0.4f;

                    obstacleSpawn.min = 2;
                    obstacleSpawn.max = 4;

                    this.GetComponent<Animator>().runtimeAnimatorController = G_L;
                    this.GetComponent<Animator>().speed = 1;

                    steps.pitch = 1.5f;
                }
                else if (skill.color == Color.blue && runUpdate == true)
                {
                    //Debug.Log("it is blue");
                    speed = 8;
                    OGSpeed = 8;
                    maxSpeed = speed * 2;
                    dashSpeed = 0.3f;

                    obstacleSpawn.min = 3;
                    obstacleSpawn.max = 5;

                    this.GetComponent<Animator>().runtimeAnimatorController = B_L;
                    this.GetComponent<Animator>().speed = 1;

                    steps.pitch = 2;
                }
                else if (skill.color == Color.red)
                {
                    //Debug.Log("it is magenta");
                    speed = 0;
                    Destroy(obstacle);
                    Destroy(collection);
                    this.GetComponent<Animator>().enabled = false;
                    //spriteRenderer.sprite = end_l;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = end_l;
                    gameOver = true;

                    steps.Stop();
                }
                //Debug.Log("Move left!");
                //this.GetComponent<Animator>().runtimeAnimatorController = O_L;
                //this.GetComponent<Animator>().speed = 1;
                //left direction animator
                //movementAnim.runtimeAnimatorController = Resources.Load("Assets/Animation/Player_L.controller") as RuntimeAnimatorController;
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            //Debug.Log("This is working");
            _trailRender.emitting = true;
            //cam_zoom.enabled = true;
            //cam_zoom.Play("Cam_Slide", 0, 0f);
            StartCoroutine(Dash());
        }
        else if (Input.GetKey(KeyCode.X))
        {
            steps.mute = true;
            //dash.mute = true;
            this.GetComponent<Animator>().speed = 0;
        }

        //checking the colour of the UI and assigning speed value
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //change player direction if they hit a wall
        if (collision.gameObject.tag == "wall")
        {
            direction.x *= -1;
            /*if (collision.gameObject.name == "Left_Tree")
            {
                //Debug.Log("collide with right");
                leaves_l.Play();
                //tree_l.GetComponent<Animation>().Play();
                //treeAnim_L.Play();
            }
            else if (collision.gameObject.name == "Right_Tree")
            {
                //Debug.Log("collide with right");
                leaves_r.Play();
                //tree_r.GetComponent<Animation>().Play();
                //treeAnim_R.Play();
            }*/
        }
        if (collision.gameObject.tag == "obstacle")
        {
            skillBar.duration += 2f;
            // flash character to be red for 1 second
            StartCoroutine(Hit());
            blood.Play();
            //play sound effect
            hitSFX.Play();
        }
        if (collision.gameObject.tag == "collect")
        {
            skillBar.duration -= 5f;
            collection.GetComponent<AudioSource>().Play();
            // flash character to be red for 1 second
            //StartCoroutine(Hit());
            //blood.Play();
            //play sound effect
            //hitSFX.Play();
        }
    }

    IEnumerator Dash()
    {
        if (speed < maxSpeed)
        {
            //dash.mute = false;
            dash.Play();
            steps.mute = true;
            //float tempPitch = steps.pitch;
            //steps.pitch = 3;
            //player.transform.localScale = new Vector3(0, 0.9f, 0);
            player.transform.localScale -= new Vector3(0, 0.2f, 0);
            player.transform.position -= new Vector3(0, 0.15f, 0);

            runUpdate = false;
            //change speed of player for 1 second and return to regular value
            speed = speed + OGSpeed;
            yield return new WaitForSeconds(dashSpeed);
            speed = speed - OGSpeed;
            runUpdate = true;
            _trailRender.emitting = false;
            
            player.transform.localScale += new Vector3(0, 0.2f, 0);
            player.transform.position += new Vector3(0, 0.15f, 0);

            steps.mute = false;
            //steps.pitch = tempPitch;

            //player.transform.localScale = new Vector3(0, 1f, 0);
        }

    }

    IEnumerator Hit()
    {
        if (direction.x == -1)
        {
            player.GetComponent<SpriteRenderer>().color = Color.black;
            l_eye.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            l_eye.SetActive(false);
            player.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (direction.x == 1)
        {
            player.GetComponent<SpriteRenderer>().color = Color.black;
            r_eye.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            r_eye.SetActive(false);
            player.GetComponent<SpriteRenderer>().color = Color.white;
        }
         
    }

}
