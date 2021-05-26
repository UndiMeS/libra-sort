using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer_number : MonoBehaviour
{

    public float number = 1;
    public bool answer = false;
    float mass2 = 0.0f;
    bool snapped = false;
    GameObject gewicht;
    Vector3 offset;
    public  int WeightInPlace = 0;
    GameObject Error;

    // Start is called before the first frame update
    void Start()
    {
        //Error = GameObject.Find("win");
    }



    // Update is called once per frame
    void Update()
    {
        if(mass2 == number)
        {
            answer = true;
            //Debug.Log("das ist richtig");
        }


        // if(snapped == true)
        // {
        //     gewicht.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);

        // }


        // gewicht.transform.position = Vector2.Lerp (gewicht.transform.position, this.transform.position, Time.deltaTime * 1.5f);

        // if (Mathf.Abs(this.transform.position.x - gewicht.transform.position.x) < 0.05)
        // {
        //     gewicht.transform.position = this.transform.position;
        // }
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
  
         

            for(int x = 1; x < 6; x++ )
            {

        if (collision.gameObject.name == "gewicht_" + x.ToString())
         {
             
           
            // Error = GameObject.Find("win");
            // WeightInPlace = Error.GetComponent<winning_script>().PlacedWeight;
            WeightInPlace++;

            

            gewicht = GameObject.Find("gewicht_" + x.ToString());

            mass2 = gewicht.GetComponent<get_mass>().mass;
            

            //snapped = true;

            // offset = gewicht.transform.position - transform.position;
            // offset.z = 0;

            // float magsqr = offset.sqrMagnitude;




            
        
       
    }
            }
    }
     private void OnTriggerStay2D(Collider2D collision)
    {

            for(int x = 1; x < 6; x++ )
            {

        if (collision.gameObject.name == "gewicht_" + x.ToString())
         {
             

             gewicht = GameObject.Find("gewicht_" + x.ToString());

            mass2 = gewicht.GetComponent<get_mass>().mass;

            //snapped = false;
            
        
       
    }
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

            for(int x = 1; x < 6; x++ )
            {

        if (collision.gameObject.name == "gewicht_" + x.ToString())
         {
            mass2 = 0.0f;
            WeightInPlace--;
            //snapped = false;
            
        
       
    }
            }
    }

}
