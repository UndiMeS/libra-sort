using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class winning_script_hard : MonoBehaviour
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

    public GameObject Vergleiche;
    TMP_Text VergleichText;

    // Start is called before the first frame update
    void Start()
    {
        //left_bowl = GameObject.Find("left_collider");
        VergleichText = Vergleiche.GetComponent<TMP_Text>();
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
            antwort = lösung.GetComponent<answer_number_hard>().answer;
            PlacedWeight = lösung.GetComponent<answer_number_hard>().WeightInPlace;
           
                WeightCount=GameObject.Find("lösung_feld_1").GetComponent<answer_number_hard>().WeightInPlace + 
                GameObject.Find("lösung_feld_2").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_3").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_4").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_5").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_6").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_7").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_8").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_9").GetComponent<answer_number_hard>().WeightInPlace +
                GameObject.Find("lösung_feld_10").GetComponent<answer_number_hard>().WeightInPlace;
            
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
            VergleichText.SetText("Vergleiche: " + CompareCounterHard.counter.ToString());
            for(int y = 1; y < 11; y++){
                nummer = GameObject.Find("lösung_nummer_" + y.ToString());
                tmpObj = nummer.GetComponent<TextMeshPro>();
                tmpObj.color = Color.green;
                StartCoroutine(ShowStarsCo());
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

        
        if(CompareCounterHard.counter > 50)
        {
            
            yield return new WaitForSeconds(1.0f);
            stars[0].SetActive(true);
            Debug.Log("vergleiche: " + CompareCounterHard.counter.ToString());
        } else if (CompareCounterHard.counter < 50 && CompareCounterHard.counter > 30)
        {
            yield return new WaitForSeconds(1.0f);
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            Debug.Log(CompareCounterHard.counter.ToString());
        }
        else{
            yield return new WaitForSeconds(1.0f);
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);
            Debug.Log("vergleiche: " + CompareCounterHard.counter.ToString());

        }
    }
     public void RestartButton()
    {
        SceneManager.LoadScene("libra_new");
    }
}
