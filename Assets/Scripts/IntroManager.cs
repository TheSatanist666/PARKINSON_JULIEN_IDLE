using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _spirits;
    [SerializeField]
    private AudioClip _monologue;
    [SerializeField]
    private AudioSource _audioSource;

    public void LaunchIntro()
    {
        _spirits.SetActive(false); //masque les esprits du decors ainsi que le bouton
        Intro();
    }

    private void Intro() //script different de LaunchIntro pour plus de clarte, il gere le monologue du personnage principal au debut
    {
        _audioSource.PlayOneShot(_monologue, 2f);
        StartCoroutine(LaunchClicker());
    }
    private IEnumerator LaunchClicker()
    {
        yield return new WaitForSeconds(21);
        SceneManager.LoadScene(1); //charge la scene principale du clicker
    }
}
