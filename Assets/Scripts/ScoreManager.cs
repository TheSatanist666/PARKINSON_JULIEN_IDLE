using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void ChangeScore(int newScore)
    {
        _score = newScore;
        scoreText.text = _score.ToString();
    }

    public void RiseScore()
    {
        ChangeScore(_score+1);
    }
}
