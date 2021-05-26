using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWeightMagnet : MonoBehaviour
{
    // Start is called before the first frame update
    public bool RightWeightInPlace = false;
    public GameObject SelectedWeightRight;

    public bool StayOnBowl;

    public float distance;

    public float RightMass;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SelectedWeightRight != null)
        {
            distance = Vector3.Distance(SelectedWeightRight.transform.position, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5.0f));
            if(RightWeightInPlace == true && SelectedWeightRight.GetComponent<DragAndDrop>().selected == false)
            {
                SelectedWeightRight.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5.0f);
                RightMass = SelectedWeightRight.GetComponent<get_mass>().mass;
            }
            

             if(SelectedWeightRight.transform.position == new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5.0f) )
        {
        
            RightWeightInPlace = true;

            


            }
            if(SelectedWeightRight.GetComponent<DragAndDrop>().selected == true)
            {
                SelectedWeightRight.GetComponent<DragAndDrop>().safePosition = true;
                RightWeightInPlace = false;
                RightMass = 0.0f;


            }

            if(RightWeightInPlace == true)
            {
                StayOnBowl = true;

                SelectedWeightRight.transform.parent = transform;
                SelectedWeightRight.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            else{
                StayOnBowl = false;

                SelectedWeightRight.transform.parent = null;
                SelectedWeightRight.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
       
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        for (int x = 1; x < 6; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {
                collision.gameObject.GetComponent<DragAndDrop>().safePosition = false;
                if(RightWeightInPlace == false)
                {
                    RightWeightInPlace = true;
                    //collision.gameObject.transform.position = this.gameObject.transform.position;

                    SelectedWeightRight = collision.gameObject;
                }
                else{
                    collision.gameObject.transform.position = collision.GetComponent<DragAndDrop>().PickUpPosition;
                }
                
            }
        }
    }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     for (int x = 1; x < 6; x++)
    //     {

    //         if (collision.gameObject.name == "gewicht_" + x.ToString())
    //         {
    //             if(collision.gameObject == SelectedWeightRight)
    //             {
    //                 SelectedWeightRight = null;
    //             }
    //         }
    //     }
    // }
}
