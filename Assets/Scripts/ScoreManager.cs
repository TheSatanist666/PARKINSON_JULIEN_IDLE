using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score;

    [SerializeField]
    private TextMeshProUGUI _scoreText, _sizeCostText, _slowCostText, _autoClickCostText; //les textes affichant le score et les couts des amelioration

    private float clickerUpgrade = 1;

    [SerializeField]
    private SpiritMovement _spiritMovement;

    private int sizeCost = 50, slowCost = 70, autoClickerCost = 10; // les couts de base des augmentations

    [SerializeField]
    private SpiritReader _spiritReader;

    private void Start()
    {
        StartCoroutine(AutoClicker()); // lance l'autoclicker (il ne fait rien gagner au debut)
    }

    public void ChangeScore(int newScore) // actualise l'affichage du score
    {
        _score = newScore;
        _scoreText.text = "Lueurs utilisables : " + _score.ToString();
    }

    public void RiseScore(int valueToAdd) // augmente de score de la valeur de l'argument
    {
        ChangeScore(_score+valueToAdd);
    }
    public void UpgradeAutoClicker() // ameliore l'autoclicker
    {
        if (_score >= autoClickerCost)
        {
            clickerUpgrade += 1.5f;
            _score -= autoClickerCost;
            autoClickerCost += 10;
            _autoClickCostText.text = "Coût : " + autoClickerCost.ToString();
            _scoreText.text = "Lueurs utilisables : " + _score.ToString();
            _spiritReader.BonusUp();
        }
        else
        {
            _autoClickCostText.text = "Lueurs insuffisantes";
            StartCoroutine(CostTextReset());
        }
    }
    public void UpgradeSize() // agrandit la taille de l'esprit
    {
        if (_score >= sizeCost)
        {
            _spiritMovement.SizeUp();
            _score -= sizeCost;
            sizeCost += 25;
            _sizeCostText.text = "Coût : " + sizeCost.ToString();
            _scoreText.text = "Lueurs utilisables : " + _score.ToString();
        }
        else
        {
            _sizeCostText.text = "Lueurs insuffisantes";
            StartCoroutine(CostTextReset());
        }
    }
    public void UpgradeSlow() // ralentit l'esprit
    {
        if (_score >= slowCost)
        {
            _spiritMovement.SlowUp();
            _score -= slowCost;
            slowCost += 25;
            _slowCostText.text = "Coût : " + slowCost.ToString();
            _scoreText.text = "Lueurs utilisables : " + _score.ToString();
        }
        else
        {
            _slowCostText.text = "Lueurs insuffisantes";
            StartCoroutine(CostTextReset());
        }
    }

    private IEnumerator AutoClicker() // ameliore l'auto Clicker
    {
        while(true)
        {
            yield return new WaitForSeconds(6/clickerUpgrade);
            if (clickerUpgrade > 1f)
            {   
                ChangeScore(_score+1);
            }
        }
    }
    private IEnumerator CostTextReset() // Actualise l'affichage des couts
    {
        yield return new WaitForSeconds(1);
        _slowCostText.text = "Coût : " + slowCost.ToString();
        _sizeCostText.text = "Coût : " + sizeCost.ToString();
        _autoClickCostText.text = "Coût : " + autoClickerCost.ToString();
    }
}
