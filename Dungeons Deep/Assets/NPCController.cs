using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public Diolauge dioluage;
    private bool speaking = false;
    private bool playerIsInRange = false;
    private bool canScroll = false; //determines wether the player can skip to the next sentence or not.
    public bool canSpeak = true;



    void Update() //checking for player interaction.
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsInRange == true && speaking == false)
        {
            PlayerController.isActive = false;
            InitializeController.diolaugeBox.SetActive(true);
            FindObjectOfType<DiolaugeManager>().StartDialogue(dioluage);
            InitializeController.promptBox.SetActive(false);
            speaking = true;
            canSpeak = false;
            StartCoroutine(startSpeaking());

        }

        if (Input.GetKeyDown(KeyCode.E) &&  speaking == true && canScroll == true) //allows player to move to next sentence.
        {
            if (FindObjectOfType<DiolaugeManager>().sentences.Count == 0)
            {
                PlayerController.isActive = true;

            }

            FindObjectOfType<DiolaugeManager>().DisplayNextSentence();

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

            speaking = false;
            canScroll = false;

        }
    }

    IEnumerator startSpeaking()
    {
        yield return new WaitForSeconds(0.2f);
        canScroll = true;
    }

}
