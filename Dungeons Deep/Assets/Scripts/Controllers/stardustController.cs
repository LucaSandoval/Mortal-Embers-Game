using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stardustController : MonoBehaviour {

    public static float starDust;
    public static float addedAmount;

    public Text starDustText;
    public Text addedAmountText;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (addedAmount > 0)
        {
            addedAmount = addedAmount - 2;
            starDust = starDust + 2;
            addedAmountText.text = "+ " + addedAmount.ToString();
            starDustText.text = starDust.ToString();
        } else
        {
            addedAmountText.text = "";
        }



    }
}
