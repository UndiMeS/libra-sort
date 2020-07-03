using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning_script : MonoBehaviour
{

    GameObject lösung;
    GameObject nummer;
    bool antwort = false;
    int antwort_zahl = 0;
    Color newColor = new Color(0.0f, 1.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        antwort_zahl = 0;
        for(int x = 1; x < 6; x++){
            lösung = GameObject.Find("lösung_feld_" + x.ToString());
            antwort = lösung.GetComponent<answer_number>().answer;
            if(antwort == true){
                antwort_zahl++;
                Debug.Log("antwort zahl: " + antwort.ToString());
            }
            else if(antwort == false){
                antwort_zahl--;
                Debug.Log("antwort zahl: " + antwort.ToString());

            }
        }

        if(antwort_zahl == 5){
            Debug.Log("komplett richtig!");
            for(int y = 1; y < 6; y++){
                nummer = GameObject.Find("lösung_nummer_" + y.ToString());
                nummer.GetComponent<TextMesh>().color = newColor;
            }
        }

    }
}
