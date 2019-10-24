using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    public GameObject itemTab;
    public GameObject charTab;
    public GameObject displayUI;
 
    public void OpenItemTab(){
        clearTabs();
        itemTab.SetActive(true);
    }

    public void OpenCharTab(){
        clearTabs();
        displayUI.SetActive(false);
        charTab.SetActive(true);
    }

    public void clearTabs(){
        itemTab.SetActive(false);
        charTab.SetActive(false);
    }
    
}
