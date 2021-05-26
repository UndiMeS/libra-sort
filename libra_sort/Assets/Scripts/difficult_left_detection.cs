using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficult_left_detection : MonoBehaviour
{

    bool isInSection1, isInSection2;
    public float mass1;
    GameObject gewicht;
    GameObject right_bowl;
    float mass_right;

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

            gewicht = GameObject.Find("difficult_gewicht_1");

            mass1 = gewicht.GetComponent<get_mass>().mass;
            //Debug.Log("links größer als rechts");
            right_bowl = GameObject.Find("right_bowl");
            mass_right = right_bowl.GetComponent<right_detection>().mass2;

            if(mass1 > mass_right)
        {
            //myrb2D.AddTorque (speed, ForceMode2D.Force);
            //Debug.Log("links größer als rechts");
        }

         }
         
     }

}
