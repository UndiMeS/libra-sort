using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl_stop_collider_hard : MonoBehaviour
{
   public GameObject theObjectToBeUnParented;
    public bool isCollidingRight = false;
    public bool isCollidingLeft = false;
    public GameObject WaageStange;
    public float speedHard = 10.0F;

    
    // private left_collider left_script;
    // private right_collider right_script;

    // private LeftWeightMagnet left_magnet_script;
    // private RightWeightMagnet right_magnet_script;
    public CompareHard compare_script;
    GameObject Getspeed;


    // Start is called before the first frame update
    void Start()
    {

         //Getspeed = GameObject.Find("left_collider");
         //left_script = GameObject.Find("left_collider").GetComponent<left_collider>();
         //right_script = GameObject.Find("right_collider").GetComponent<right_collider>();

         
         //right_magnet_script = GameObject.Find("MagnetPositionRight").GetComponent<RightWeightMagnet>();
    }

    // Update is called once per frame
    void Update()
    {

        WaageStange = GameObject.Find("waage_stange");
        compare_script = WaageStange.GetComponent<CompareHard>();
        // for (int x = 1; x < 6; x++)
        // {

        //     if (this.gameObject.transform.parent.name == "gewicht_" + x.ToString())
        //     {


        
        if(isCollidingRight == true)
        {
            speedHard = 0.0f;
            //compare_script.speed = speed;
            CompareHard.speedHard = speedHard;
            //left_script.speed = 0.0f;
            theObjectToBeUnParented.transform.parent = null;
            //WaageStange.GetComponent<Rigidbody2D>().freezeRotation;
            //left_script.WeightCollider = true;
            //right_script.WeightCollider = true;

        }
        if(isCollidingRight == false && isCollidingLeft == false){
            speedHard = 1.0f;
            //compare_script.speed = speed;
            CompareHard.speedHard = speedHard;
            //left_script.speed = 1.0f;
            
            
        }

         else if(isCollidingLeft == true)
        {
            speedHard = 0.0f;
            //compare_script.speed = speed;
            CompareHard.speedHard = speedHard;
            //right_script.speed = 0.0f;
            theObjectToBeUnParented.transform.parent = null;
            //WaageStange.GetComponent<Rigidbody2D>().freezeRotation;
            //left_script.WeightCollider = true;
            //right_script.WeightCollider = true;

        }
        if(isCollidingLeft == false && isCollidingRight == false){
            speedHard = 1.0f;
            //compare_script.speed = speed;
            CompareHard.speedHard = speedHard;
            //right_script.speed = 1.0f;
             
            
        }
        //     }
        // }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        


        if(collision.gameObject.name == "right_bowl")
        {
            isCollidingRight = true;
            //isCollidingLeft = false;

        }

        if(collision.gameObject.name == "left_bowl")
        {
            isCollidingLeft = true;
            //isCollidingRight = false;

        }

    }

    // void OnTriggerStay2D(Collider2D collision)
    // {

    //     if(collision.gameObject.name == "right_bowl")
    //     {
    //         isCollidingRight = true;
    //         //isCollidingLeft = false;

    //     }

    //     if(collision.gameObject.name == "left_bowl")
    //     {
    //         isCollidingLeft = true;
    //         //isCollidingRight = false;

    //     }

    // }

    void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.name == "right_bowl")
        {
            isCollidingRight = false;
            isCollidingLeft = false;
            //right_script.WeightCollider = false;

        }

        if(collision.gameObject.name == "left_bowl")
        {
            isCollidingLeft = false;
            isCollidingRight = false;
            //left_script.WeightCollider = false;

        }
    }
}
