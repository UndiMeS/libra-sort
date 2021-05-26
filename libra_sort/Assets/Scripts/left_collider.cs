using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_collider : MonoBehaviour
{

    public Rigidbody2D rigidBody2D;
    float wait = 0.0f;
    Rigidbody2D myrb2D;
    public float speed = 0F;
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
    public int stepTotal;
    GameObject gewicht_collider;
    public bool WeightCollider;
    float compare_delay = 0.1f;
    public int WeightCount;

    public GameObject LeftMagnet;
    public GameObject LeftBowlWeight;

    Vector3 triggerPosition;




    GameObject pole;
    // Start is called before the first frame update
    void Start()
    {
        pole = GameObject.Find("waage_stange");
        left_bowl = GameObject.Find("left_collider");
        //gewicht_collider = GameObject.Find("gewicht_collider");
        WeightCount = 0;



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        LeftBowlWeight = LeftMagnet.GetComponent<LeftWeightMagnet>().SelectedWeightLeft;

        triggerPosition = new Vector3 (left_bowl.transform.position.x, left_bowl.transform.position.y - left_bowl.transform.position.y/2, left_bowl.transform.position.z);

        right_bowl = GameObject.Find("right_collider");
        //gewicht_collider = GameObject.Find("gewicht_collider");
        //speed = gewicht_collider.GetComponent<bowl_stop_collider>().speed;

        
        mass_right = right_bowl.GetComponent<right_collider>().mass2;

        even2 = right_bowl.GetComponent<right_collider>().even;

        stepTotal = right_bowl.GetComponent<right_collider>().step;

        //WeightCollider = gewicht_collider.GetComponent<bowl_stop_collider>().isColliding;
       

        if (left == true)
        {
            pole.transform.rotation = Quaternion.Slerp(pole.transform.rotation, Quaternion.Euler(0, 0, 45), Time.deltaTime * speed);
            even = false;
            right = false;
            even2 = false;
            
            right_bowl.GetComponent<right_collider>().WeightCollider = false;

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
            
        }


    }



    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {

        // for (int x = 1; x < 6; x++)
        // {
        //     if (collision.gameObject.name == "gewicht_" + x.ToString())
        //     {

                 //collision.transform.parent = this.transform;

                 if(collision.gameObject == LeftBowlWeight)
                 {

                right_bowl = GameObject.Find("right_collider");
                mass_right = right_bowl.GetComponent<right_collider>().mass2;


                //gewicht = GameObject.Find("gewicht_" + x.ToString());

                gewicht = LeftBowlWeight;

                WeightCount = WeightCount +1;

                if(WeightCount>1)
                {
                    //this.transform.localScale += new Vector3(0.0f, 1.5f,0.0f);
                    //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.75f, 0.0f);
                }


                if(WeightCount <= 1)
                {
                    
                }
                mass1 = gewicht.GetComponent<get_mass>().mass;
                    //mass1 = mass1 + mass_stay;
                    //mass_stay = mass1;
                    even2 = right_bowl.GetComponent<right_collider>().even;


                

                

                // if(collision.transform.position == triggerPosition)
                // {
                //     collision.transform.parent = transform;
                //     gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                //     gewicht.transform.parent = this.transform;
                // }

               


                if (mass1 > mass_right)
                {
                    yield return new WaitForSeconds(compare_delay);
                    left = true;
                    even = false;
                    //even2 = false;
                    right = false;
                    //right_bowl.GetComponent<right_collider>().even = false;

                    staying = true;
                    yield return new WaitForSeconds(wait);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            
                            staying = false;
                            if(WeightCount <= 1)
                            {
                                //CompareCounter.counter += 1;
                            }
                            
                        }

                    }

                }
                else if (mass1 < mass_right)
                {
                    yield return new WaitForSeconds(compare_delay);

                    even = false;
                    //even2 = true;
                    left = false;
                    right = true;
                    //Debug.Log("alles gleich");

                    staying = true;
                    yield return new WaitForSeconds(wait);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            
                            staying = false;

                            if(WeightCount <= 1)
                            {
                                //CompareCounter.counter += 1;
                            }
                        }

                    }

                }
                else if (mass1 == mass_right)
                {

                    yield return new WaitForSeconds(compare_delay);
                    even = true;
                    //even2 = true;
                    left = false;
                    right = false;
                    //Debug.Log("alles gleich");

                    staying = true;
                    yield return new WaitForSeconds(wait);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            
                            staying = false;
                            if(WeightCount <= 1)
                            {
                                //CompareCounter.counter += 1;
                            }
                        }

                    }

                }
            }
         }
    // }

    IEnumerator OnTriggerStay2D(Collider2D collision)
    {

        // for (int x = 1; x < 6; x++)
        // {

        //     if (collision.gameObject.name == "gewicht_" + x.ToString())
        //     {

                 if(collision.gameObject == LeftBowlWeight)
                 {


                right_bowl = GameObject.Find("right_collider");
                mass_right = right_bowl.GetComponent<right_collider>().mass2;

                //gewicht = GameObject.Find("gewicht_" + x.ToString());

                gewicht = LeftBowlWeight;

                mass1 = gewicht.GetComponent<get_mass>().mass;
                even2 = right_bowl.GetComponent<right_collider>().even;
                //mass1 = mass1 + mass_stay;

                // collision.transform.parent = transform;
                // gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;


                if (mass1 > mass_right)
                {
                    yield return new WaitForSeconds(compare_delay);
                    left = true;
                    even = false;
                    //even2 = false;
                    right = false;
                    //right_bowl.GetComponent<right_collider>().even = false;

                }
                else if (mass1 < mass_right)
                {
                    yield return new WaitForSeconds(compare_delay);

                    even = false;
                    //even2 = true;
                    left = false;
                    right = true;
                    //Debug.Log("alles gleich");

                }
                else if (mass1 == mass_right)
                {
                    yield return new WaitForSeconds(compare_delay);

                    even = true;
                    //even2 = true;
                    left = false;
                    right = false;
                    //Debug.Log("alles gleich");

                }
            }
        //}
    }

    IEnumerator OnTriggerExit2D(Collider2D collision)
    {


        // for (int x = 1; x < 6; x++)
        // {
        //     if (collision.gameObject.name == "gewicht_" + x.ToString())
        //     {

                             if(collision.gameObject == LeftBowlWeight)
                 {
                right_bowl = GameObject.Find("right_collider");
                mass_right = right_bowl.GetComponent<right_collider>().mass2;
                even2 = right_bowl.GetComponent<right_collider>().even;
                
                WeightCount = WeightCount -1;
                if(WeightCount<2)
                    {
                        //this.transform.localScale -= new Vector3(0.0f, 1.5f,0.0f);
                        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.75f, 0.0f);
                    }


                //gewicht = GameObject.Find("gewicht_" + x.ToString());
                //mass1 = gewicht.GetComponent<get_mass>().mass;

                mass1 = LeftBowlWeight.GetComponent<get_mass>().mass;

                //mass_stay = mass_stay - mass1;

                mass1 = 0;

                //collision.transform.parent = null;
                gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                if (mass1 > mass_right)
                {

                    even = false;
                    //even2 = false;
                    left = false;
                    right = true;

                    staying = true;
                    yield return new WaitForSeconds(wait);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            
                            staying = false;
                            //CompareCounter.counter += 1;
                        }

                    }
                }
                else if (mass1 < mass_right)
                {

                    yield return new WaitForSeconds(compare_delay);
                    even = false;
                    //even2 = true;
                    left = false;
                    right = true;
                    //Debug.Log("alles gleich");

                    staying = true;
                    yield return new WaitForSeconds(wait);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            
                            staying = false;

                            //CompareCounter.counter += 1;
                        }
                    }
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

                    yield return new WaitForSeconds(compare_delay);
                    even = true;
                    //even2 = false;
                    left = false;
                    right = false;

                    staying = true;
                    yield return new WaitForSeconds(wait);
                    if(staying){
                        if(mass1 != 0 && mass_right != 0){
                            step = step + 1;
                            stepTotal = step + stepTotal;
                            
                            staying = false;
                            //CompareCounter.counter += 1;
                        }

                    }


                }
            }
        //}
    }

}
