using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_mass : MonoBehaviour
{

    public float mass = 0.0f;
    GameObject gewicht;
    public bool landing = false;
    AudioSource Drop;


    // Start is called before the first frame update
    void Start()
    {
        Drop = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void FixedUpdate()
 {
         if (landing)
         {
             this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
             landing = false;
         }
 }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(Time.timeScale != 0.0F)
        {
            Drop.Play();
            //Drop.mute = true;
        }
        

        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("gewicht_" + x.ToString());
                landing = true;

                //gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {

                gewicht = GameObject.Find("gewicht_" + x.ToString());

                //collision.transform.parent = transform;
                //gewicht.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Drop.mute = false;
    }

   

}
