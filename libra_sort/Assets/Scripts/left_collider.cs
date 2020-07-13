using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_collider : MonoBehaviour
{

    public Rigidbody2D rigidBody2D;
    Rigidbody2D myrb2D;
    public float speed = 10F;
    GameObject right_bowl;
    GameObject gewicht;
    GameObject left_bowl;
    public float mass1;
    float mass_stay = 0.0F;
    public float mass_right;
    bool left = false;
    bool right = false;
    public bool even = false;
    bool even2 = false;
    bool staying = false;
    public int step;
    static int stepTotal;




    GameObject pole;
    // Start is called before the first frame update
    void Start()
    {
        pole = GameObject.Find("waage_stange");

    }

    // Update is called once per frame
    void Update()
    {
        right_bowl = GameObject.Find("right_collider");

        even2 = right_bowl.GetComponent<right_collider>().even;

        stepTotal = right_bowl.GetComponent<right_collider>().step;

        if (left == true)
        {
            pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, 45), Time.deltaTime * speed);
            even = false;
            right = false;
            even2 = false;
            Debug.Log("links größer als rechts: " + mass1.ToString());

        }
        //  if(right == true){
        //     pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, -45), Time.deltaTime * speed);
        //     even = false;
        //     left = false;
        //     even2=false;

        //     Debug.Log("rechts größer als links");
        // }
        else if (even2 == true)
        {
            pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed);
            left = false;
            right = false;
            Debug.Log("alles gleich");
        }


    }

private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int x = 1; x < 6; x++)
        {
            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {
               
            }
        }
    }

    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     for (int x = 1; x < 6; x++)
    //     {
    //         if (collision.gameObject.name == "gewicht_" + x.ToString())
    //         {
    //             collision.collider.transform.SetParent(transform);
    //         }
    //     }
    // }


    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {

        for (int x = 1; x < 6; x++)
        {
            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {

                 //collision.transform.parent = this.transform;

                right_bowl = GameObject.Find("right_collider");
                mass_right = right_bowl.GetComponent<right_collider>().mass2;


                gewicht = GameObject.Find("gewicht_" + x.ToString());




                mass1 = gewicht.GetComponent<get_mass>().mass;
                mass1 = mass1 + mass_stay;
                mass_stay = mass1;
                even2 = right_bowl.GetComponent<right_collider>().even;

                Debug.Log("collision");

                collision.transform.parent = transform;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                //gewicht.transform.parent = this.transform;


                if (mass1 > mass_right)
                {

                    left = true;
                    even = false;
                    //even2 = false;
                    right = false;
                    //right_bowl.GetComponent<right_collider>().even = false;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                }
                else if (mass1 < mass_right)
                {


                    even = false;
                    //even2 = true;
                    left = false;
                    right = true;
                    //Debug.Log("alles gleich");

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;

                            CompareCounter.counter += 1;
                        }

                    }

                }
                else if (mass1 == mass_right)
                {


                    even = true;
                    //even2 = true;
                    left = false;
                    right = false;
                    //Debug.Log("alles gleich");

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {




                right_bowl = GameObject.Find("right_collider");
                mass_right = right_bowl.GetComponent<right_collider>().mass2;

                gewicht = GameObject.Find("gewicht_" + x.ToString());

                //mass1 = gewicht.GetComponent<get_mass>().mass;
                even2 = right_bowl.GetComponent<right_collider>().even;
                //mass1 = mass1 + mass_stay;

                // collision.transform.parent = transform;
                // gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;


                if (mass1 > mass_right)
                {

                    left = true;
                    even = false;
                    //even2 = false;
                    right = false;
                    //right_bowl.GetComponent<right_collider>().even = false;

                }
                else if (mass1 < mass_right)
                {


                    even = false;
                    //even2 = true;
                    left = false;
                    right = true;
                    //Debug.Log("alles gleich");

                }
                else if (mass1 == mass_right)
                {


                    even = true;
                    //even2 = true;
                    left = false;
                    right = false;
                    //Debug.Log("alles gleich");

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
                right_bowl = GameObject.Find("right_collider");
                mass_right = right_bowl.GetComponent<right_collider>().mass2;
                even2 = right_bowl.GetComponent<right_collider>().even;
                

                gewicht = GameObject.Find("gewicht_" + x.ToString());
                mass1 = gewicht.GetComponent<get_mass>().mass;

                mass_stay = mass_stay - mass1;

                mass1 = mass_stay;

                collision.transform.parent = null;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                if (mass1 > mass_right)
                {

                    even = false;
                    //even2 = false;
                    left = false;
                    right = true;


                }
                else if (mass1 < mass_right)
                {


                    even = false;
                    //even2 = true;
                    left = false;
                    right = true;
                    //Debug.Log("alles gleich");

                }
                // if(mass1 > mass_right)
                // {

                //     even = false;
                //     even2 = false;
                //     left = true;
                //     right = false;


                // }
                else if (mass_right == mass1)
                {


                    even = true;
                    //even2 = false;
                    left = false;
                    right = false;




                }
            }
        }
    }
}
