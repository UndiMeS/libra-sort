using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficult_right_collider : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D myrb2D;
    Vector3 currentEulerAngles;
    public float speed = 0.0F;
    GameObject right_bowl;
    GameObject gewicht;
    GameObject pole;
    GameObject left_bowl;
    GameObject gewicht_collider;
    public float mass2;
    float mass_stay = 0.0F;
    float besetztMass = 0.0f;
    float mass_left;
    float compare_delay = 0.1f;

    public int step;
    static int stepTotal;

    public bool WeightCollider;

    bool right = false;
    bool left = false;
    public bool even = false;
    bool even2 = false;
    bool besetzt = false;
    bool staying = false;

    void Start()
    {
        pole = GameObject.Find("waage_stange");
        gewicht_collider = GameObject.Find("gewicht_collider");
    }

    // Update is called once per frame
    void Update()
    {

        left_bowl = GameObject.Find("left_collider");

        //speed = gewicht_collider.GetComponent<bowl_stop_collider>().speed;

        even2 = left_bowl.GetComponent<difficult_left_collider>().even;

        stepTotal = left_bowl.GetComponent<difficult_left_collider>().step;

        if (right == true && WeightCollider == false)
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

        // if (WeightCollider == true)
        // {
        //     left_bowl.GetComponent<left_collider>().WeightCollider = false;
        // }



    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {


        for (int x = 1; x < 11; x++)
        {

            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {



                left_bowl = GameObject.Find("left_collider");
                mass_left = left_bowl.GetComponent<difficult_left_collider>().mass1;

                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());

                mass2 = gewicht.GetComponent<difficult_get_mass>().mass;
                mass2 = mass2 + mass_stay;
                mass_stay = mass2;
                even2 = left_bowl.GetComponent<difficult_left_collider>().even;

                //collision.transform.parent = transform;
                //gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;




                //gewicht.transform.parent = this.transform;

                if (mass2 > mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    right = true;
                    even = false;
                    even2 = false;
                    left = false;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass2 != 0 && mass_left != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }
                    

                }
                else if (mass2 < mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = false;
                    even2 = false;
                    right = false;
                    left = true;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass2 != 0 && mass_left != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                    

                }
                else if (mass2 == mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = true;
                    even2 = true;
                    right = false;
                    left = false;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass2 != 0 && mass_left != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                    

                }

            }
            // besetzt = true;
            //     besetztMass = mass2;
        }
    }

    IEnumerator OnTriggerStay2D(Collider2D collision)
    {

        for (int x = 1; x < 11; x++)
        {
            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {
                //besetzt = true;
                left_bowl = GameObject.Find("left_collider");
                mass_left = left_bowl.GetComponent<difficult_left_collider>().mass1;

                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());

                //mass2 = gewicht.GetComponent<get_mass>().mass;
                even2 = left_bowl.GetComponent<difficult_left_collider>().even;

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
                    yield return new WaitForSeconds(compare_delay);
                    right = true;
                    even = false;
                    even2 = false;
                    left = false;


                }
                else if (mass2 < mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = false;
                    even2 = false;
                    right = false;
                    left = true;


                }
                else if (mass2 == mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = true;
                    even2 = true;
                    right = false;
                    left = false;


                }
            }
        }
    }

    IEnumerator OnTriggerExit2D(Collider2D collision)
    {

        for (int x = 1; x < 11; x++)
        {
            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {
                left_bowl = GameObject.Find("left_collider");
                mass_left = left_bowl.GetComponent<difficult_left_collider>().mass1;
                

                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());
                mass2 = gewicht.GetComponent<difficult_get_mass>().mass;

                mass_stay = mass_stay - mass2;

                mass2 = mass_stay;

                even2 = left_bowl.GetComponent<difficult_left_collider>().even;
                //collision.transform.parent = null;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                staying = false;

                if (mass2 > mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = false;
                    even2 = false;
                    left = false;
                    right = true;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass2 != 0 && mass_left != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                }
                else if (mass2 < mass_left)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = false;
                    even2 = false;
                    right = false;
                    left = true;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass2 != 0 && mass_left != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                }
                else if (mass_left == mass2)
                {
                    yield return new WaitForSeconds(compare_delay);
                    even = true;
                    even2 = true;
                    left = false;
                    right = false;

                    staying = true;
                    yield return new WaitForSeconds(1);
                    if(staying){
                        if(mass2 != 0 && mass_left != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            Debug.Log("schritt rechts: " + stepTotal);
                            staying = false;
                            CompareCounter.counter += 1;
                        }

                    }

                }

            }
            // besetzt = false;
            // mass2 = besetztMass - mass2;
        }
    }
}
