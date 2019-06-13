using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeUpAI : MonoBehaviour {

    public float moveSpeed; // floats controlling movement speed, shoot speed, patrol size, maximum bullets, reload speed and ammo
    public float patrolArea;
    public float prepTime; //the time it takes to become active


    private bool inRange;
    private bool inWakeRange;
    private bool active;
    private bool awake;

    private Animator anim;



    private Transform playerPosition;
    public Transform rangeCheck;
    public float checkRadius;
    public LayerMask whatisPlayer;

    private Vector2 randPosition;

    private Rigidbody2D rb;

    private Light li;

    public Transform wakeCheck;
    public float wakeCheckRadius;



    void Start () {

        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // this gets the position of the player so the AI can use it 

        randPosition = new Vector2(Random.Range(transform.position.x + patrolArea, transform.position.x + patrolArea), Random.Range(transform.position.y + patrolArea, transform.position.y + patrolArea)); // this gets a random vector2 so the AI can use it to wander

        rb = GetComponent<Rigidbody2D>();

        anim = this.GetComponent<Animator>();
        inRange = false;
        inWakeRange = false;
        active = false;
        awake = false;

        anim.SetBool("active", false);
        anim.SetBool("awake", false);

        InvokeRepeating("generatePosition", 0, Random.Range(1, 5)); // starts the generate position class every second

        li = this.GetComponentInChildren<Light>();

        li.enabled = false;
    }

    void Update () {
        if (awake == true)
        {
            inRange = Physics2D.OverlapCircle(rangeCheck.position, checkRadius, whatisPlayer);

        }

        if (awake == false)
        {
            inWakeRange = Physics2D.OverlapCircle(wakeCheck.position, wakeCheckRadius, whatisPlayer);

        }

        if (inRange == true && awake == true) // this checks if the okayer is in range of the AI and starts moving towards it
        {
            //moves grunt every frame.
            rb.velocity = (playerPosition.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        else if (awake == true)
        {
            rb.velocity = (new Vector3(randPosition.x, randPosition.y, 0) - transform.position).normalized * moveSpeed / 2 * Time.deltaTime; // otherwise constantly moves towards a new random position
        }

        handAnimations();

        if (active == false && inWakeRange == true)
        {
            active = true;
            anim.SetBool("active", true);
            StartCoroutine(wakeUp());

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Bullet")
        {
            Destroy(other);
        }
    }


    IEnumerator wakeUp()
    {
        li.enabled = true;
        yield return new WaitForSeconds(prepTime);
        anim.SetBool("awake", true);
        awake = true;
    }

    public void generatePosition() // this gets a random vector2 so the AI can use it to wander
    {
        randPosition = new Vector2(Random.Range(transform.position.x - patrolArea, transform.position.x + patrolArea), Random.Range(transform.position.y - patrolArea, transform.position.y + patrolArea));

    }

    public void handAnimations() // handles animating for movement.
    {
        if (rb.velocity.y < 0)
        {
            //checks if the enemies x velocity is great enough to cause the left/right animations to play instead of up/down.
            if (rb.velocity.x > 2 / moveSpeed)
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Up", false);
                anim.SetBool("Left", false);
                anim.SetBool("Right", true);

            }
            else if (rb.velocity.x < -1 * (2 / moveSpeed))
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Up", false);
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);

            }
            else
            {
                anim.SetBool("Forward", true);
                anim.SetBool("Up", false);
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);

            }

        }
        else if (rb.velocity.y > 0)
        {
            //checks if the enemies x velocity is great enough to cause the left/right animations to play instead of up/down.
            if (rb.velocity.x > 2 / moveSpeed)
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Up", false);
                anim.SetBool("Left", false);
                anim.SetBool("Right", true);

            }
            else if (rb.velocity.x < -1 * (2 / moveSpeed))
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Up", false);
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);

            }
            else
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Up", true);
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);

            }
        }
    }
}
