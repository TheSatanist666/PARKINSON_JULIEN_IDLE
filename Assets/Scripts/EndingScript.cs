using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{

    [SerializeField]
    private AudioClip _line1, _line2, _line3, _line4, _line5, _line6, _line7, _line8, _line9, _line10;
    [SerializeField]
    private AudioSource _audioSource;
    private int voiceline;
    [SerializeField]
    private Image _brother, _father, _mother, _dog;
    [SerializeField]
    private GameObject _fin;

    void Start()
    {
        _fin.SetActive(false);
        voiceline = 1;
        StartCoroutine(TimeToSpaceVoicelines());
    }

    private IEnumerator TimeToSpaceVoicelines() //Coroutine qui se fait succéder les lignes de dialogue
    {
        if (voiceline == 1)
        {
            yield return new WaitForSeconds(3);
            _audioSource.PlayOneShot(_line1); // Mere : Tu m'as manque, mon cheri.
            _mother.transform.localScale = _mother.transform.localScale * 1.6f;
            yield return new WaitForSeconds(2);
            voiceline = 2;
            StartCoroutine(TimeToSpaceVoicelines());
            _mother.transform.localScale = _mother.transform.localScale / 1.6f;
        }
        if (voiceline == 2)
        {
            _audioSource.PlayOneShot(_line2); // Pere : Nous sommes tous fier de toi.
            yield return new WaitForSeconds(2);
            _father.transform.localScale = _father.transform.localScale * 1.2f;
            yield return new WaitForSeconds(3);
            voiceline = 3;
            StartCoroutine(TimeToSpaceVoicelines());
            _father.transform.localScale = _father.transform.localScale / 1.2f;
        }
        if (voiceline == 3)
        {
            _audioSource.PlayOneShot(_line3); // Chien : Wouf
            _dog.transform.localScale = _dog.transform.localScale * 1.1f;
            yield return new WaitForSeconds(2);
            voiceline = 4;
            StartCoroutine(TimeToSpaceVoicelines());
            _dog.transform.localScale = _dog.transform.localScale / 1.1f;
        }
        if (voiceline == 4)
        {
            _audioSource.PlayOneShot(_line4, 0.3f); // Frere : Ça fait plaisir de te voir une derniere fois
            _brother.transform.localScale = _brother.transform.localScale * 1.04f;
            yield return new WaitForSeconds(4);
            voiceline = 5;
            StartCoroutine(TimeToSpaceVoicelines());
            _brother.transform.localScale = _brother.transform.localScale / 1.04f;
        }
        if (voiceline == 5)
        {
            _audioSource.PlayOneShot(_line5, 0.3f); // Enfant :  Waw.. Ça marche vraiment.. Et bien voila. Adieu
            yield return new WaitForSeconds(5);
            voiceline = 6;
            StartCoroutine(TimeToSpaceVoicelines());
        }
        if (voiceline == 6)
        {
            _audioSource.PlayOneShot(_line6, 0.1f); // Mere : Ce n'est qu'un au revoir !
            yield return new WaitForSeconds(1);
            _mother.transform.localScale = _mother.transform.localScale * 1.01f;
            yield return new WaitForSeconds(1.5f);
            voiceline = 7;
            StartCoroutine(TimeToSpaceVoicelines());
            _mother.enabled = false;
        }
        if (voiceline == 7)
        {
            _audioSource.PlayOneShot(_line7, 0.1f); // Pere : Un jour tu seras aussi à nos cotes
            _father.transform.localScale = _father.transform.localScale * 1.01f;
            yield return new WaitForSeconds(4);
            voiceline = 8;
            StartCoroutine(TimeToSpaceVoicelines());
            _father.enabled = false;
        }
        if (voiceline == 8)
        {
            _audioSource.PlayOneShot(_line8, 0.1f); // Frere : Mais ne nous rejoins pas avant longtemps hein !
            _brother.transform.localScale = _brother.transform.localScale * 1.004f;
            yield return new WaitForSeconds(4f);
            voiceline = 9;
            StartCoroutine(TimeToSpaceVoicelines());
            _brother.enabled = false;
        }
        if (voiceline == 9)
        {
            _audioSource.PlayOneShot(_line9, 0.2f); // Chien : Wouf
            _dog.transform.localScale = _dog.transform.localScale * 1.004f;
            yield return new WaitForSeconds(2);
            _dog.enabled = false;
            yield return new WaitForSeconds(2);
            voiceline = 10;
            StartCoroutine(TimeToSpaceVoicelines());
        }
        if (voiceline == 10)
        {
            _audioSource.PlayOneShot(_line10, 0.1f); // Enfant : Vous voyez, cette fois je vous l'ai dit ! J'ai pu vous dire adieu.
            yield return new WaitForSeconds(1);
            EndTheGame();
        }
    }
    private void EndTheGame()
    {
        _fin.SetActive(true);
    }
}
