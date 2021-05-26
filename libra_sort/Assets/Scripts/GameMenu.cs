using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject Restart;
    public GameObject Continue;
    public GameObject Quit;
    AudioSource button;

    public bool isPause;

    // Start is called before the first frame update
    void Start()
    {
       button = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        button.Play();
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueButton()
    {
        button.Play();
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void RestartButton()
    {
        button.Play();
        SceneManager.LoadScene("libra_new");
    }

    public void QuitGame()
    {
        button.Play();
        Application.Quit();
    }

   
}
