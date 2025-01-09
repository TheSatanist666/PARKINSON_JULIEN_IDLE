using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpPannel : MonoBehaviour
{
    private Image helpPannel;
    [SerializeField]
    private TextMeshProUGUI _helpText;

    // Repere et cache le panneau d'aide au debut
    void Start()
    {
        helpPannel = GetComponent<Image>();
        helpPannel.enabled = false;
        _helpText.enabled = false;
    }

    public void ShowOrHideHelp() //affiche le panneau d'aide s'il est cache ou le cache s'il est affiche
    {
        if (helpPannel.enabled == false)
        {
            helpPannel.enabled = true;
            _helpText.enabled = true;
        }
        else
        {
            helpPannel.enabled = false;
            _helpText.enabled = false;
        }
    }
}
