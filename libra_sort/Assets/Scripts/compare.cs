using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compare : MonoBehaviour
{

    
    public Rigidbody2D myrb2D;
    public static float speed;
    GameObject right_bowl;
    GameObject left_bowl;
    public GameObject right_magnet;
    public GameObject left_magnet;
    public float mass_left;
    public float mass_right;

    public GameObject[] stopcolliders;
    public bool stop_true;

    // Start is called before the first frame update
    void Start()
    {
        myrb2D = this.GetComponent<Rigidbody2D>();
        stopcolliders = GameObject.FindGameObjectsWithTag("stop");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        foreach(GameObject stopcollider in stopcolliders)
        {
            if(stopcollider.GetComponent<bowl_stop_collider>().speed == 0.0f)
            {
                if(stopcollider.transform.parent.GetComponent<DragAndDrop>().selected == false)
                {
                    speed = 0.0f;
                }
                
                //stop_true = true;
            }
        }
        
    


        //left_bowl = GameObject.Find("left_bowl");
        // mass_left = left_bowl.GetComponent<left_detection>().mass1;

        //right_bowl = GameObject.Find("right_bowl");
        // mass_right = right_bowl.GetComponent<right_detection>().mass2;

        mass_right = right_magnet.GetComponent<RightWeightMagnet>().RightMass;
        mass_left = left_magnet.GetComponent<LeftWeightMagnet>().LeftMass;

        if(mass_left > mass_right)
        {
            //Debug.Log("links größer als rechts");
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.Euler(0, 0, 45), Time.deltaTime * speed);

            foreach(GameObject stopcollider in stopcolliders)
        {
            if(stopcollider.GetComponent<bowl_stop_collider>().isCollidingRight == true)
            {

                stopcollider.GetComponent<bowl_stop_collider>().isCollidingRight = false;
                //stop_true = true;
            }
        }
            
            //right_bowl.GetComponent<right_collider>().WeightCollider = false;

        }
        if(mass_left < mass_right)
        {
            //myrb2D.AddTorque (speed, ForceMode2D.Force);
            //Debug.Log("rechts größer als lins");
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.Euler(0, 0, -45), Time.deltaTime * speed);
            //left_bowl.GetComponent<left_collider>().WeightCollider = false;

             foreach(GameObject stopcollider in stopcolliders)
        {
            if(stopcollider.GetComponent<bowl_stop_collider>().isCollidingLeft == true)
            {

                stopcollider.GetComponent<bowl_stop_collider>().isCollidingLeft = false;
                //stop_true = true;
            }
        }
        }
        
        if(mass_left == mass_right)
        {
            //myrb2D.MoveRotation(myrb2D.rotation + speed * Time.deltatime );
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed);

            foreach(GameObject stopcollider in stopcolliders)
        {
            if(stopcollider.GetComponent<bowl_stop_collider>().isCollidingLeft == true)
            {

                stopcollider.GetComponent<bowl_stop_collider>().isCollidingLeft = false;
                //stop_true = true;
            }
            if(stopcollider.GetComponent<bowl_stop_collider>().isCollidingRight == true)
            {

                stopcollider.GetComponent<bowl_stop_collider>().isCollidingRight = false;
                //stop_true = true;
            }
        }
        
        }
            
        
    }
}
