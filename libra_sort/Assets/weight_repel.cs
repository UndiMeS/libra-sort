using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight_repel : MonoBehaviour
{

    public float thrust = -5.0f;
     private Rigidbody2D rb2D;
    static GameObject gewicht;
    private bool hit = false;
     public float speed;
          float force = 300;

          private bool wallTrigger;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb2D.AddForce(transform.up * thrust);
        // if(hit = true){
        //         float step = speed * Time.deltaTime;
        //         this.transform.position.x + 2;
        //  transform.position = Vector3.MoveTowards(transform.position, gewicht.transform.position, step);
        //  //gewicht.transform.position = Vector3.MoveTowards(gewicht.transform.position, transform.position, step);
        // }
        
        
}

void OnTriggerEnter2D (Collider2D other)
     {
         wallTrigger = false;
     }
 
     void OnTriggerExit2D (Collider2D other)
     {
         wallTrigger = true;
 
         var magnitude = 2500;
 
         var force = transform.position - other.transform.position;
 
         force.Normalize ();
         GetComponent<Rigidbody2D> ().AddForce (-force * magnitude);
 
 
     }

 private void OnCollisionEnter2D(Collision2D collision)
    {


        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("gewicht_" + x.ToString());
                hit = true;
                //gewicht.transform.position = this.transform.position;
                //rb2D = gewicht.GetComponent<Rigidbody2D>();
                 // Calculate Angle Between the collision point and the player
        

            }
        }
    }


private void OnCollisionExit2D(Collision2D collision)
    {


        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("gewicht_" + x.ToString());
                hit = false;
                //gewicht.transform.position = this.transform.position;
                //rb2D = gewicht.GetComponent<Rigidbody2D>();

            }
        }
    }

}