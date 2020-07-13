using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_menu : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject IntroText;
    public GameObject IntroText2;
    public GameObject NextIntroButton;

    public bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        StartMenu.SetActive(true);
        IntroText.SetActive(false);
        IntroText2.SetActive(false);
        //NextIntroButton.SetActive(false);
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartMenu.SetActive(false);
        IntroText.SetActive(true);
        IntroText2.SetActive(false);
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
        NextIntroButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
