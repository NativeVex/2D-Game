using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    public AudioClip audio1;
    public Button Start;
    public Button QuitButton;
    public Text Title;
    public Button Back;
    public Text Instruction;
    public Button InstructionsButton;

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
        SceneManager.LoadScene("level 1 ");
    }

    public void Instructions()
    {
        QuitButton.gameObject.SetActive(false);
        Start.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        Instruction.gameObject.SetActive(true);
        InstructionsButton.gameObject.SetActive(false);
        Back.gameObject.SetActive(true);
        Back.GetComponent<Button>().interactable = true;
        Back.GetComponent<Button>().enabled = true;
        QuitButton.GetComponent<Button>().interactable = false;
        QuitButton.GetComponent<Button>().enabled = false;
        Start.GetComponent<Button>().interactable = false;
        Start.GetComponent<Button>().enabled = false;
        InstructionsButton.GetComponent<Button>().interactable = false;
        InstructionsButton.GetComponent<Button>().enabled = false;
    }

    public void Menu()
    {
        QuitButton.gameObject.SetActive(true);
        Start.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
        Instruction.gameObject.SetActive(false);
        InstructionsButton.gameObject.SetActive(true);
        Back.gameObject.SetActive(false);
        Back.GetComponent<Button>().interactable = false;
        Back.GetComponent<Button>().enabled = false;
        QuitButton.GetComponent<Button>().interactable = true;
        QuitButton.GetComponent<Button>().enabled = true;
        Start.GetComponent<Button>().interactable = true;
        Start.GetComponent<Button>().enabled = true;
        InstructionsButton.GetComponent<Button>().interactable = true;
        InstructionsButton.GetComponent<Button>().enabled = true;
    }
}
