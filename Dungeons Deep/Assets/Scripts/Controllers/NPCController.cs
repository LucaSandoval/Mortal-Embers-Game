using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public Diolauge dioluage;
    private bool speaking = false;
    private bool playerIsInRange = false;
    private bool canScroll = false; //determines wether the player can skip to the next sentence or not.



    void Update() //checking for player interaction.
    {
        if (PlayerController.dashing == false && pauseController.gamePaused == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsInRange == true && speaking == false)
            {
                //PlayerController.isActive = false;
                FindObjectOfType<DiolaugeManager>().StartDialogue(dioluage);
                InitializeController.promptBox.SetActive(false);
                speaking = true;
                StartCoroutine(startSpeaking());

            }

            if (Input.GetKeyDown(KeyCode.E) &&  speaking == true && canScroll == true) //allows player to move to next sentence.
            {

            FindObjectOfType<DiolaugeManager>().DisplayNextSentence();

        }

        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsInRange = true;

            InitializeController.promptBox.SetActive(true);
            InitializeController.promptText.text = "Speak";

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsInRange = false;

            InitializeController.promptBox.SetActive(false);
            InitializeController.diolaugeBox.SetActive(false);

            speaking = false;
            canScroll = false;
            DiolaugeManager.inDiolauge = false;

        }
    }

    IEnumerator startSpeaking()
    {
        yield return new WaitForSeconds(0.2f);
        canScroll = true;
    }

}
