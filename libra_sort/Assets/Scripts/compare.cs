using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compare : MonoBehaviour
{

    
    public Rigidbody2D myrb2D;
    public float speed;
    GameObject right_bowl;
    GameObject left_bowl;
    float mass_left;
    float mass_right;

    // Start is called before the first frame update
    void Start()
    {
        myrb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        left_bowl = GameObject.Find("left_bowl");
        mass_left = left_bowl.GetComponent<left_detection>().mass1;

        right_bowl = GameObject.Find("right_bowl");
        mass_right = right_bowl.GetComponent<right_detection>().mass2;

        if(mass_left > mass_right)
        {
            //Debug.Log("links größer als rechts");

        }
        if(mass_left < mass_right)
        {
            //myrb2D.AddTorque (speed, ForceMode2D.Force);
            //Debug.Log("rechts größer als lins");
        }
        if(mass_left == mass_right)
        {
            //myrb2D.MoveRotation(myrb2D.rotation + speed * Time.deltatime );
        }
    }
}
