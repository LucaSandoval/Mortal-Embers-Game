using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    // varios floats for movement controll.
    public float speed;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private bool dashing;
    public static bool invincible;
    public static Transform globalPLayerPosition;

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

        if (Input.GetKeyDown(KeyCode.Space) && StatController.Stamina > 4) //checks input for dashing
        {
            dashing = true;
            invincible = true;
            StatController.Stamina = StatController.Stamina - 4;
            VisualEffects.spawnDashEffect(transform);
            rb.velocity = new Vector2(moveInput.x, moveInput.y) * 15;
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
        if(dashing == false)
        {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        }
        
      
    } //sets velocity to keyboard input every frame.

    void HandleAnims() // handles animation for movment.
    {
        if (Input.GetKey(KeyCode.A))
        {
            

            anim.SetBool("left", true);
            anim.SetBool("idle", false);
            anim.SetBool("up", false);
            anim.SetBool("forward", false);

            anim.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            
            anim.SetBool("right", true);
            anim.SetBool("idle", false);
            anim.SetBool("up", false);
            anim.SetBool("forward", false);
            anim.SetBool("left", false);

        }

        if (Input.GetKey(KeyCode.W))
        {
           
            anim.SetBool("up", true);
            anim.SetBool("idle", false);

            anim.SetBool("forward", false);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            
            anim.SetBool("forward", true);
            anim.SetBool("idle", false);
            anim.SetBool("up", false);

            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            anim.SetBool("idle", true);
            anim.SetBool("up", false);
            anim.SetBool("forward", false);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }
    }

    IEnumerator dash() //makes it so you can't infinitely dash.
    {
        yield return new WaitForSeconds(0.1f);
        dashing = false;
        VisualEffects.spawnDashEffect(transform);

        invincible = false;


    }


}
