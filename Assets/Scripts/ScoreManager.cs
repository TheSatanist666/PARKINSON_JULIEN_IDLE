using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private float clickerUpgrade = 1;

    private void Start()
    {
        StartCoroutine(MaCoroutine());
    }

    public void ChangeScore(int newScore)
    {
        _score = newScore;
        _scoreText.text = "Lueurs utilisables : " + _score.ToString();
    }

    public void RiseScore()
    {
        ChangeScore(_score+1);
    }
    public void UpgradeAutoClicker()
    {
        clickerUpgrade += 0.5f;
    }

    private IEnumerator MaCoroutine()
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
}
