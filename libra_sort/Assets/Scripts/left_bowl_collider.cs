using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_bowl_collider : MonoBehaviour
{

    public bool isCollidingWeight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {



            if (collision.gameObject.name == "gewicht_collider")
            {
                isCollidingWeight = true;
            }

        
    }

    void OnCollisionStay2D(Collision2D collision)
    {



            if (collision.gameObject.name == "gewicht_collider")
            {
                isCollidingWeight = true;
            }

        
    }

    void OnCollisionExit2D(Collision2D collision)
    {

            if (collision.gameObject.name == "gewicht_collider")
            {
                isCollidingWeight = false;
            }

        
    }


}
