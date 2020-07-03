using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_collider : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D myrb2D;
    Vector3 currentEulerAngles;
    public float speed = 0.1F;
    GameObject right_bowl;
    GameObject gewicht;
    GameObject pole;
    GameObject left_bowl;
    public float mass2;
    float mass_stay = 0.0F;
    float besetztMass = 0.0f;
    float mass_left;

    bool right = false;
    bool left = false;
    public bool even = false;
    bool even2 = false;
    bool besetzt = false;

    void Start()
    {
        pole = GameObject.Find("waage_stange");
    }

    // Update is called once per frame
    void Update()
    {

        left_bowl = GameObject.Find("left_collider");

        even2 = left_bowl.GetComponent<left_collider>().even;

        if (right == true)
        {
            pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, -45), Time.deltaTime * speed);
            even = false;
            left = false;
            even2 = false;
            Debug.Log("rechts größer als links: " + mass2.ToString());

        }
        // if(left == true){
        //     pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, 45), Time.deltaTime * speed);
        //     even = false;
        //     right = false;
        //     even2 = false;
        //     Debug.Log("links größer als rechts");
        // }
        else if (even2 == true)
        {
            pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed);
            right = false;
            left = false;
            //even = true;
            Debug.Log("alles gleich");

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {



                left_bowl = GameObject.Find("left_collider");
                mass_left = left_bowl.GetComponent<left_collider>().mass1;

                gewicht = GameObject.Find("gewicht_" + x.ToString());

                mass2 = gewicht.GetComponent<get_mass>().mass;
                mass2 = mass2 + mass_stay;
                mass_stay = mass2;
                even2 = left_bowl.GetComponent<left_collider>().even;

                collision.transform.parent = transform;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;


                //gewicht.transform.position = this.transform.position;

                if (mass2 > mass_left)
                {

                    right = true;
                    even = false;
                    even2 = false;
                    left = false;

                }
                else if (mass2 < mass_left)
                {

                    even = false;
                    even2 = false;
                    right = false;
                    left = true;

                }
                else if (mass2 == mass_left)
                {

                    even = true;
                    even2 = true;
                    right = false;
                    left = false;

                }

            }
            // besetzt = true;
            //     besetztMass = mass2;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        for (int x = 1; x < 6; x++)
        {
            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {
                //besetzt = true;
                left_bowl = GameObject.Find("left_collider");
                mass_left = left_bowl.GetComponent<left_collider>().mass1;

                gewicht = GameObject.Find("gewicht_" + x.ToString());

                //mass2 = gewicht.GetComponent<get_mass>().mass;
                even2 = left_bowl.GetComponent<left_collider>().even;

                //  if(besetzt == true && x > 1)
                // {
                //     mass2 = mass2 + besetztMass;
                //     Debug.Log("recht: " + mass2);
                // }

                //gewicht.transform.position = this.transform.position;

                // collision.transform.parent = transform;
                // gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                if (mass2 > mass_left)
                {

                    right = true;
                    even = false;
                    even2 = false;
                    left = false;

                }
                else if (mass2 < mass_left)
                {

                    even = false;
                    even2 = false;
                    right = false;
                    left = true;

                }
                else if (mass2 == mass_left)
                {

                    even = true;
                    even2 = true;
                    right = false;
                    left = false;

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        for (int x = 1; x < 6; x++)
        {
            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {
                left_bowl = GameObject.Find("left_collider");
                mass_left = left_bowl.GetComponent<left_collider>().mass1;
                

                gewicht = GameObject.Find("gewicht_" + x.ToString());
                mass2 = gewicht.GetComponent<get_mass>().mass;

                mass_stay = mass_stay - mass2;

                mass2 = mass_stay;

                even2 = left_bowl.GetComponent<left_collider>().even;
                collision.transform.parent = null;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                if (mass2 > mass_left)
                {
                    even = false;
                    even2 = false;
                    left = false;
                    right = true;

                }
                else if (mass2 < mass_left)
                {

                    even = false;
                    even2 = false;
                    right = false;
                    left = true;

                }
                else if (mass_left == mass2)
                {
                    even = true;
                    even2 = true;
                    left = false;
                    right = false;

                }

            }
            // besetzt = false;
            // mass2 = besetztMass - mass2;
        }
    }
}
