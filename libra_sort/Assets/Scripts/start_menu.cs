using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class start_menu : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject DifficultMenu;
    public GameObject IntroText;
    public GameObject IntroText2;
    public GameObject NextIntroButton;
    public GameObject EasyMode;
    public GameObject HardMode;
    AudioSource button;

    public bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        StartMenu.SetActive(true);
        DifficultMenu.SetActive(false);
        IntroText.SetActive(false);
        IntroText2.SetActive(false);
        //NextIntroButton.SetActive(false);
        Time.timeScale = 0f;
        button = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        button.Play();
        StartMenu.SetActive(false);
        DifficultMenu.SetActive(false);
        IntroText.SetActive(true);
        IntroText2.SetActive(false);
        EasyMode.SetActive(true);
        HardMode.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void NextIntro()
    {
        IntroText.SetActive(false);
        IntroText2.SetActive(true);
        //NextIntroButton.SetActive(true);

    }

    public void IntroFinish()
    {
        IntroText.SetActive(false);
        IntroText2.SetActive(false);
        DifficultMenu.SetActive(false);
        NextIntroButton.SetActive(false);
    }

    public void QuitGame()
    {
        button.Play();
        Application.Quit();
    }

    public void Difficulty()
    {
        button.Play();
        DifficultMenu.SetActive(true);
        StartMenu.SetActive(false);
        IntroText.SetActive(false);
        IntroText2.SetActive(false);
    }

   
}
