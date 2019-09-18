using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    // varios floats for movement controll.
    public float speed;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public static bool dashing;
    private bool dashInput;
    public static bool invincible;
    public static Transform globalPLayerPosition;

    public static bool isActive = true;

    private float facing = 0;

    // 0 - Down, 1 - Up, 2 - Left, 3 - Right

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("left", false);
        anim.SetBool("idle", true);
        anim.SetBool("up", false);
        anim.SetBool("forward", false);
        anim.SetBool("right", false);

        dashing = false;
        dashInput = false;
        invincible = false;
       

    }
	
	// Update is called once per frame
	void Update () {

        HandleAnims();

        // gets the input from the keyboard for movement.
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (wishingStarController.isHealing == false) //checks wether or not to slow you down if you are using the wishing star.
        {
            moveVelocity = moveInput.normalized * speed;

        } else
        {
            moveVelocity = moveInput.normalized * speed / 3;

        }

        if (Input.GetKeyDown(KeyCode.Space) && StatController.Stamina > 0 && dashInput == false) //checks input for dashing
        {
            dashing = true;
            dashInput = true;
            invincible = true;
            StatController.Stamina = StatController.Stamina - 4;
            rb.velocity = new Vector2(moveInput.x, moveInput.y) * 15;



            if (facing == 0)
            {
                anim.SetBool("forwardRoll", true);
            } else if (facing == 1)
            {
                anim.SetBool("upRoll", true);
            } else if (facing == 2)
            {
                anim.SetBool("leftRoll", true);
            } else if (facing == 3)
            {
                anim.SetBool("rightRoll", true);
            }

            StartCoroutine(dash());
        }

        globalPLayerPosition = this.transform;
    }

    private void FixedUpdate()
    {
              
        handleMove();

    }

    void handleMove()
    {
        if (isActive == true)
        {
            if(dashing == false)
            {
                rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

            }

        }
        
      
    } //sets velocity to keyboard input every frame.

    void HandleAnims() // handles animation for movment.
    {

        if (Input.GetKey(KeyCode.A))
        {
            facing = 2;

            anim.SetBool("upIdle", false);
            anim.SetBool("leftIdle", false);
            anim.SetBool("rightIdle", false);
            anim.SetBool("left", true);
            anim.SetBool("idle", false);
            anim.SetBool("up", false);
            anim.SetBool("forward", false);

            anim.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            facing = 3;

            anim.SetBool("upIdle", false);
            anim.SetBool("leftIdle", false);
            anim.SetBool("rightIdle", false);
            anim.SetBool("right", true);
            anim.SetBool("idle", false);
            anim.SetBool("up", false);
            anim.SetBool("forward", false);
            anim.SetBool("left", false);

        }

        if (Input.GetKey(KeyCode.W))
        {
            facing = 1;

            anim.SetBool("upIdle", false);
            anim.SetBool("leftIdle", false);
            anim.SetBool("rightIdle", false);
            anim.SetBool("up", true);
            anim.SetBool("idle", false);

            anim.SetBool("forward", false);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            facing = 0;

            anim.SetBool("upIdle", false);
            anim.SetBool("leftIdle", false);
            anim.SetBool("rightIdle", false);
            anim.SetBool("forward", true);
            anim.SetBool("idle", false);
            anim.SetBool("up", false);

            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            anim.SetBool("up", false);
            anim.SetBool("forward", false);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("idle", false);
            anim.SetBool("upIdle", false);
            anim.SetBool("leftIdle", false);
            anim.SetBool("rightIdle", false);

            if (facing == 0)
            {
                anim.SetBool("idle", true);

            } else if (facing == 1)
            {
                anim.SetBool("upIdle", true);

            } else if (facing == 2)
            {
                anim.SetBool("leftIdle", true);

            }
            else if (facing == 3)
            {
                anim.SetBool("rightIdle", true);

            }

        }
    }

    IEnumerator dash() //makes it so you can't infinitely dash.
    {
        yield return new WaitForSeconds(0.12f);
        anim.SetBool("forwardRoll", false);
        anim.SetBool("upRoll", false);
        anim.SetBool("leftRoll", false);
        anim.SetBool("rightRoll", false);

        dashing = false;


        invincible = false;

        yield return new WaitForSeconds(0.2f);

        dashInput = false;


    }


}
