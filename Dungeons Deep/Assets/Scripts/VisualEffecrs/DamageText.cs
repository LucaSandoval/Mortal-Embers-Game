using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {


    public Animator anim;
    private Text damageText;


	void Start () {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length - 0.1f);
        damageText = anim.GetComponent<Text>();
	}
	
    public void SetText(string text)
    {
        anim.GetComponent<Text>().text = text;
    }

    public void SetColor(string color)
    {
        damageText = anim.GetComponent<Text>();

        if (color == "Gray")
        {
            damageText.color = Color.gray;

        } else if (color == "Red")
        {

            damageText.color = Color.red;

        }
        else if (color == "Green")
        {
            damageText.color = Color.green;

        } else if (color == "Blue")
        {
            damageText.color = Color.blue;
        } else
        {
            Debug.Log(color + " is not a valid color!");
        }
    }

}
