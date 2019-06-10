using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiolaugeManager : MonoBehaviour {


    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Queue<string> sentences;

    public static bool inDiolauge = false;


    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue(Diolauge dialogue)
    {
        InitializeController.diolaugeBox.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        inDiolauge = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }




    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        InitializeController.diolaugeBox.SetActive(false);
        inDiolauge = false;
    }
}
