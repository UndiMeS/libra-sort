using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompareCounter : MonoBehaviour
{

    public GameObject LeftMagnet;
    public GameObject RightMagnet;
    public bool Compare;
    public static int counter = 0;
    TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if(LeftMagnet.GetComponent<LeftWeightMagnet>().LeftWeightInPlace == true && RightMagnet.GetComponent<RightWeightMagnet>().RightWeightInPlace == true && Compare == false)
        {
            counter = counter +1;
            Compare = true;
        }
        else if(LeftMagnet.GetComponent<LeftWeightMagnet>().LeftWeightInPlace == false || RightMagnet.GetComponent<RightWeightMagnet>().RightWeightInPlace == false)
        {
            Compare = false;
        }

        score.SetText("Vergleich: " + counter);
    }
}
