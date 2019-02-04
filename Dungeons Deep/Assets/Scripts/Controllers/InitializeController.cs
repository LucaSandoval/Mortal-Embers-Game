using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeController : MonoBehaviour {

    public static GameObject promptBox;
    public static GameObject diolaugeBox;
    public static Text promptText;

    public void Start()
    {
        promptBox = GameObject.FindGameObjectWithTag("promptBox"); // returns 'promptBox' which allows for dropped items to refrence it.
        promptText = GameObject.FindGameObjectWithTag("promptText").GetComponent<Text>(); // returns 'promtText' which allows for interactables to change what its message is.
        promptBox.SetActive(false);

        diolaugeBox = GameObject.FindGameObjectWithTag("diolaugeBox");
        diolaugeBox.SetActive(false);


    }

}
