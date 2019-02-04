using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public Diolauge dioluage;
    private bool speaking = false;
    private bool playerIsInRange = false;



    void Update() //checking for player interaction.
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsInRange == true && speaking == false)
        {
            speaking = true;
            PlayerController.isActive = false;
            InitializeController.diolaugeBox.SetActive(true);
            FindObjectOfType<DiolaugeManager>().StartDialogue(dioluage);
            InitializeController.promptBox.SetActive(false);
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

        }
    }

}
