using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject  settingsPanel;
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void settingsButtonOnClick()
    {
        settingsPanel.SetActive(true);
    }
    public void settingsExitButtonOnClick()
    {
        settingsPanel.SetActive(false);
    }
    public void exitButtonOnClick(){
        Application.Quit();
    }
}
