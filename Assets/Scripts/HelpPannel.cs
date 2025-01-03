using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpPannel : MonoBehaviour
{
    private Image helpPannel;
    [SerializeField]
    private TextMeshProUGUI helpText;

    // Repere et cache le panneau d'aide au debut
    void Start()
    {
        helpPannel = GetComponent<Image>();
        helpPannel.enabled = false;
        helpText.enabled = false;
    }

    public void ShowOrHideHelp() //affiche le panneau d'aide s'il est cache ou le cache s'il est affiche
    {
        if (helpPannel.enabled == false)
        {
            helpPannel.enabled = true;
            helpText.enabled = true;
        }
        else
        {
            helpPannel.enabled = false;
            helpText.enabled = false;
        }
    }
}
