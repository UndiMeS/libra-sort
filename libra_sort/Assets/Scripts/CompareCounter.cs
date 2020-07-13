using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompareCounter : MonoBehaviour
{

    public static int counter = 0;
    TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText("Vergleich: " + counter);
    }
}
