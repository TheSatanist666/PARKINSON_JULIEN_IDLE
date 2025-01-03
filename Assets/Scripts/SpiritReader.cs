using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpiritReader : MonoBehaviour
{
    [SerializeField]
    private Image _spiritImage; //image de l'esprit

    [SerializeField]
    private SpiritUnit _currentSpirit; //esprit actuel

    [SerializeField]
    private SpiritUnit[] _bag; //sac (ensemble d'esprits)

    private ScoreManager _scoreManager; //gestion du score

    [SerializeField]
    private TextMeshProUGUI _blueScoreText, _redScoreText, _yellowScoreText, _greenScoreText; //textes ou sont notes les pourcentages de recolte des esprits

    private float blueScore, redScore, yellowScore, greenScore; //scores representants les pourcentages de remplissage des esprits (0 = 0% ; 200 = 0%)

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        ReadSpirit(_bag[Random.Range(0,_bag.Length)]); //selectionne aleatoirement un esprit dans le sac
    }

    public void ChangeSpirit() //remplace l'esprit actuel par un nouvel esprit venant du sac
    {
        _scoreManager.RiseScore();
        ReadSpirit(_bag[Random.Range(0, _bag.Length)]);
    }
    
    private void ReadSpirit(SpiritUnit newSpirit) //effectue les changements lies à la presence de l'esprit actuel
    {
        _currentSpirit = newSpirit;

        _spiritImage.sprite = _currentSpirit.spiritImage;

        switch (_currentSpirit.color)
        {
            case SpiritColor.Blue: //si l'esprit est bleu, alors le pourcentage de fragments bleu augmente, et l'affichage change
                if (blueScore < 200)
                {
                    blueScore += 1;
                    _blueScoreText.text = "esprit bleu : " + (blueScore / 2).ToString() + "%";
                }
                break;
            case SpiritColor.Red: //si l'esprit est rouge, alors le pourcentage de fragments rouge augmente, et l'affichage change
                if (redScore < 200)
                {
                    redScore += 1;
                    _redScoreText.text = "esprit rouge : " + (redScore / 2).ToString() + "%";
                }
                break;
            case SpiritColor.Green: //si l'esprit est vert, alors le pourcentage de fragments vert augmente, et l'affichage change
                if (greenScore < 200)
                {
                    greenScore += 1;
                    _greenScoreText.text = "esprit vert : " + (greenScore / 2).ToString() + "%";
                }
                break;
            case SpiritColor.Yellow: //si l'esprit est jaune, alors le pourcentage de fragments jaune augmente, et l'affichage change
                if (yellowScore < 200)
                {
                    yellowScore += 1;
                    _yellowScoreText.text = "esprit jaune : " + (yellowScore / 2).ToString() + "%";
                }
                break;
        }
        if ((blueScore == 200 && redScore == 200) && (greenScore == 200 && yellowScore == 200))
        {
            SceneManager.LoadScene(2);
        }
    }

}
