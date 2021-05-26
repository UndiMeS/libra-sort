using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SchwierigkeitMenu : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject DifficultMenu;
    public GameObject Normal;
    public GameObject Difficult;
    public GameObject Back;
    public GameObject EasyMode;
    public GameObject HardMode;
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
        DifficultMenu.SetActive(true);
        StartMenu.SetActive(false);
        
        Time.timeScale = 0f;
    }

    public void NormalButton()
    {
        button.Play();
        //SceneManager.LoadScene("libra_1");
        DifficultMenu.SetActive(false);
        StartMenu.SetActive(false);
        EasyMode.SetActive(true);
        Time.timeScale = 1f;
    }

    public void SchwierigButton()
    {
        button.Play();
        DifficultMenu.SetActive(false);
        StartMenu.SetActive(false);
        EasyMode.SetActive(false);
        HardMode.SetActive(true);
        Time.timeScale = 1f;
        //SceneManager.LoadScene("libra_2");
    }

    public void BackToMenu()
    {
        button.Play();
        DifficultMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

   
}
