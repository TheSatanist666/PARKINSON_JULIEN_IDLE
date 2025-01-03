using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score;

    [SerializeField]
    private TextMeshProUGUI _scoreText, _sizeCostText, _slowCostText, _autoClickCostText;

    private float clickerUpgrade = 1;

    [SerializeField]
    private SpiritMovement _spiritMovement;

    private int sizeCost = 50, slowCost = 70, autoClickerCost = 5;

    private void Start()
    {
        StartCoroutine(AutoClicker());
    }

    public void ChangeScore(int newScore)
    {
        _score = newScore;
        _scoreText.text = "Lueurs utilisables : " + _score.ToString();
    }

    public void RiseScore(int valueToAdd)
    {
        ChangeScore(_score+valueToAdd);
    }
    public void UpgradeAutoClicker()
    {
        if (_score >= autoClickerCost)
        {
            clickerUpgrade += 1.5f;
            _score -= autoClickerCost;
            autoClickerCost += 5;
            _autoClickCostText.text = "Coût : " + autoClickerCost.ToString();
            _scoreText.text = "Lueurs utilisables : " + _score.ToString();
        }
        else
        {
            _autoClickCostText.text = "Lueurs insuffisantes";
            StartCoroutine(CostTextReset());
        }
    }
    public void UpgradeSize()
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
    public void UpgradeSlow()
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

    private IEnumerator AutoClicker()
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
    private IEnumerator CostTextReset()
    {
        yield return new WaitForSeconds(1);
        _slowCostText.text = "Coût : " + slowCost.ToString();
        _sizeCostText.text = "Coût : " + sizeCost.ToString();
        _autoClickCostText.text = "Coût : " + autoClickerCost.ToString();
    }
}
