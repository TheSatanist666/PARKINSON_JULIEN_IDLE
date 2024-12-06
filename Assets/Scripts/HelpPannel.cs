using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPannel : MonoBehaviour
{
    private Image helpPannel;

    // Repere et cache le panneau d'aide au debut
    void Start()
    {
        helpPannel = GetComponent<Image>();
        helpPannel.enabled = false;
    }

    public void ShowOrHideHelp() //affiche le panneau d'aide s'il est cache ou le cache s'il est affiche
    {
        if (helpPannel.enabled == false)
        {
            helpPannel.enabled = true;
        }
        else
        {
            helpPannel.enabled = false;
        }
    }
}
