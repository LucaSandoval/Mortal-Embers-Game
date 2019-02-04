using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaManager : MonoBehaviour {

    public int areaID = 1;
    public int emberID = 1;
    private string areaName = "null";
    private string emberName = "null";

    private Text areNameText;
    private Text emberNameText;

    private void Start()
    {
        areNameText = GameObject.FindGameObjectWithTag("areaText").GetComponent<Text>();
        emberNameText = GameObject.FindGameObjectWithTag("emberText").GetComponent<Text>();


        switch (areaID)
        {
            case 1:
                areaName = "Stonefall Tower";
                break;
            case 2:
                areaName = "Mortal Garden";
                break;
            case 3:
                areaName = "Old Keep of Embers";
                break;
            default:
                areaName = "null";
                break;
        }

        switch (emberID)
        {
            case 1:
                emberName = "Ember of Dark";
                break;
            case 2:
                emberName = "Ember of Wrath";
                break;
            case 3:
                emberName = "Ember of Faith";
                break;
            default:
                emberName = "null";
                break;
        }


        emberNameText.text = emberName;
        areNameText.text = areaName;

    }
}
