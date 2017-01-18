using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    public AudioClip audio1;
	public void Quit()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        audio.clip = audio1;
        audio.Play(); 
       // print("Quit");
        Application.Quit();
    }

    public void Begin()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        audio.clip = audio1;
        audio.Play(); 
       // print("Begin");
        SceneManager.LoadScene("Level Tutorial");
    }
}
