using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHighlight : MonoBehaviour
{
    bool highlighted;
    public void Select(){
        
        if (highlighted == false){
            GetComponent<Button>().image.color = new Color(0.2f, 0.2f, 0.2f, 1);
        } else {
            GetComponent<Button>().image.color = new Color(0, 0, 0, 1);
        }

        highlighted = !highlighted;
    }

    void OnEnable(){
        highlighted = false;
        GetComponent<Button>().image.color = new Color(0, 0, 0, 1);
    }

}
