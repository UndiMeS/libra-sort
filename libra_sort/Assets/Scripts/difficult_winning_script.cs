using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class difficult_winning_script : MonoBehaviour
{

    public GameObject[] stars;
    public GameObject WinCanvas;
    GameObject lösung;
    GameObject nummer;
    GameObject feld;
    bool antwort = false;
    int antwort_zahl = 0;
    public int PlacedWeight = 0;
    Color newColor = new Color(0.0f, 1.0f, 0.0f);
    private TextMeshPro tmpObj;
    int CompareCount;
    GameObject left_bowl;
    public int WeightCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //left_bowl = GameObject.Find("left_collider");
    }

    // Update is called once per frame
    void Update()
    {

        // left_bowl = GameObject.Find("left_collider");
        // CompareCount = left_bowl.GetComponent<left_collider>().CompareCounter.count;

        antwort_zahl = 0;
        
        //PlacedWeight = 0;
        for(int x = 1; x < 11; x++){
            lösung = GameObject.Find("lösung_feld_" + x.ToString());
            //PlacedWeight = lösung.GetComponent<winning_script>().WeightInPlace;
            antwort = lösung.GetComponent<difficult_answer_number>().answer;
            PlacedWeight = lösung.GetComponent<difficult_answer_number>().WeightInPlace;
           
                WeightCount=GameObject.Find("lösung_feld_1").GetComponent<difficult_answer_number>().WeightInPlace + 
                GameObject.Find("lösung_feld_2").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_3").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_4").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_5").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_6").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_7").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_8").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_9").GetComponent<difficult_answer_number>().WeightInPlace +
                GameObject.Find("lösung_feld_10").GetComponent<difficult_answer_number>().WeightInPlace;
            
            if(antwort == true){
                antwort_zahl++;
                Debug.Log("antwort zahl: " + antwort.ToString());
                //PlacedWeight++;
            }
            else if(antwort == false){
                antwort_zahl--;
                Debug.Log("antwort zahl: " + antwort.ToString());
                //PlacedWeight++;

            }
        }
        if(antwort_zahl == 10){
            Debug.Log("komplett richtig!");
            if(CompareCounter.counter < 20){
                Debug.Log("Zu wenig Versuche bei 10 Massestücke!");
                for(int y = 1; y < 11; y++){
                    nummer = GameObject.Find("lösung_nummer_" + y.ToString());
                    tmpObj = nummer.GetComponent<TextMeshPro>();
                    tmpObj.color = Color.red;
                }
            }else if(CompareCounter.counter >= 20 && WeightCount == 10){
                for(int y = 1; y < 11; y++){
                    nummer = GameObject.Find("lösung_nummer_" + y.ToString());
                    tmpObj = nummer.GetComponent<TextMeshPro>();
                    tmpObj.color = Color.green;
                    StartCoroutine(ShowStarsCo());
                }
            }
        }
        else if(antwort_zahl!=10 && WeightCount == 10) {
           
            for(int y = 1; y < 11; y++){
                nummer = GameObject.Find("lösung_nummer_" + y.ToString());
                tmpObj = nummer.GetComponent<TextMeshPro>();
                tmpObj.color = Color.red;
            }
        }
        else if(antwort_zahl!=10 && WeightCount != 10){
            for(int y = 1; y < 11; y++){
                nummer = GameObject.Find("lösung_nummer_" + y.ToString());
                    tmpObj = nummer.GetComponent<TextMeshPro>();
                    tmpObj.color = Color.white;
                    }
        }

    }

    IEnumerator ShowStarsCo(){
        WinCanvas.SetActive(true);
        
        if(CompareCounter.counter > 20 && CompareCounter.counter < 30)
        {
            yield return new WaitForSeconds(1.0f);
            stars[0].SetActive(true);
            Debug.Log("vergleiche: " + CompareCounter.counter.ToString());
        } else if (CompareCounter.counter < 20 && CompareCounter.counter > 10)
        {
            yield return new WaitForSeconds(1.0f);
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            Debug.Log("vergleiche: " + CompareCounter.counter.ToString());
        }
        else{
            yield return new WaitForSeconds(1.0f);
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);
            Debug.Log("vergleiche: " + CompareCounter.counter.ToString());

        }
    }
     public void RestartButton()
    {
        SceneManager.LoadScene("libra_1");
    }
}
