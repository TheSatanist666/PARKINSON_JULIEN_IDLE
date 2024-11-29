using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        ReadSpirit(_bag[Random.Range(0,_bag.Length)]); //sélectionne aleatoirement un esprit dans le sac
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
            case SpiritColor.Blue:
                Camera.main.backgroundColor = Color.blue;
                break;
            case SpiritColor.Red:
                Camera.main.backgroundColor = Color.red;
                break;
            case SpiritColor.Green:
                Camera.main.backgroundColor = Color.green;
                break;
            case SpiritColor.Yellow:
                Camera.main.backgroundColor = Color.yellow;
                break;
            default:
                break;
        }
    }

}
