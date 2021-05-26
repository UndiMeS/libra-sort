using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficult_right_detection : MonoBehaviour
{

    bool isInSection1, isInSection2;
    public float mass2;
    GameObject gewicht2;
     GameObject left_bowl;
    float mass_left;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.name == "difficult_gewicht_1")
         {
             isInSection1 = true;
             isInSection2 = false;

            gewicht2 = GameObject.Find("difficult_gewicht_1");

            mass2 = gewicht2.GetComponent<get_mass>().mass;
            //Debug.Log("rechts größer als lins");

            left_bowl = GameObject.Find("left_bowl");
            mass_left = left_bowl.GetComponent<left_detection>().mass1;

            if(mass2 > mass_left)
        {
            //myrb2D.AddTorque (speed, ForceMode2D.Force);
            //Debug.Log("rechts größer als links");
        }
         }
         
     }

}
