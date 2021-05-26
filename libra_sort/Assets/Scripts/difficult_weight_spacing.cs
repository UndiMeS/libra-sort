using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficult_weight_spacing : MonoBehaviour
{

    GameObject gewicht;
    bool StayOnBowl = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(StayOnBowl == true){
        //     gewicht.transform.parent = transform;
        //         gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        // }
        // if(StayOnBowl == false){
        //     gewicht.transform.parent = null;
        //         gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        // }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {


        for (int x = 1; x < 11; x++)
        {

            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());

                StayOnBowl = true;

                collision.transform.parent = transform;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        for (int x = 1; x < 11; x++)
        {

            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());

                StayOnBowl = true;

                collision.transform.parent = transform;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {


        for (int x = 1; x < 11; x++)
        {

            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());

                StayOnBowl = false;

                collision.transform.parent = null;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
