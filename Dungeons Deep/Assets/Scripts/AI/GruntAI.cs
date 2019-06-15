using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntAI : MonoBehaviour {


    public float moveSpeed; // floats controlling movement speed, shoot speed, patrol size, maximum bullets, reload speed and ammo
    public float patrolArea;


    private bool inRange; // boolean initilization for logic control


    private Transform playerPosition;
    public Transform rangeCheck;
    public float checkRadius;
    public LayerMask whatisPlayer;

    private Vector2 randPosition;

    private Rigidbody2D rb;

    private Animator anim;
    
   
    void Start () { // runs on play


        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // this gets the position of the player so the AI can use it 

        inRange = false;

        randPosition = new Vector2(Random.Range(transform.position.x + patrolArea, transform.position.x + patrolArea), Random.Range(transform.position.y + patrolArea, transform.position.y + patrolArea)); // this gets a random vector2 so the AI can use it to wander

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        InvokeRepeating("generatePosition", 0, Random.Range(1,5)); // starts the generate position class every second




        handAnimations(); // runs animation check on start.

       
    }
	

	void Update () { // runs once per frame

        inRange = Physics2D.OverlapCircle(rangeCheck.position, checkRadius, whatisPlayer);

        if (inRange == true) // this checks if the okayer is in range of the AI and starts moving towards it
        {
            //moves grunt every frame.
            rb.velocity = (playerPosition.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = (new Vector3(randPosition.x, randPosition.y, 0) - transform.position).normalized * moveSpeed / 2 * Time.deltaTime; // otherwise constantly moves towards a new random position
        }


        handAnimations();

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


    public void generatePosition() // this gets a random vector2 so the AI can use it to wander
    {
        randPosition = new Vector2(Random.Range(transform.position.x - patrolArea, transform.position.x + patrolArea), Random.Range(transform.position.y - patrolArea, transform.position.y + patrolArea)); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other);
        }
    }

    public void knockback(float power)
    {
        rb.AddForce(new Vector2(rb.velocity.x * -power, rb.velocity.y * -power));
    }


}
