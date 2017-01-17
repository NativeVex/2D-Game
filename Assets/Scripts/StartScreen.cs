using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
	
	void Quit()
    {
        Application.Quit();
    }

    void Begin()
    {
        SceneManager.LoadScene("level 1");
    }
}
