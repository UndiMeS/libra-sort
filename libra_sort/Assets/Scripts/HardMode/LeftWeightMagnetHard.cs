using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeightMagnetHard : MonoBehaviour
{
    // Start is called before the first frame update
    public bool LeftWeightInPlace = false;
    public GameObject SelectedWeightLeft;

    public bool StayOnBowl;
    //public BoxCollider2D LeftWeightCollider;

    public float LeftMass;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SelectedWeightLeft != null)
        {
            if(LeftWeightInPlace == true && SelectedWeightLeft.GetComponent<DragAndDrop>().selected == false)
            {
                SelectedWeightLeft.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5.0f);
                //LeftWeightCollider.enabled = false;
                LeftMass = SelectedWeightLeft.GetComponent<get_mass>().mass;
            }
            

             if(SelectedWeightLeft.transform.position == new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5.0f) )
        {
            LeftWeightInPlace = true;




            }
            if(SelectedWeightLeft.GetComponent<DragAndDrop>().selected == true)
            {
                SelectedWeightLeft.GetComponent<DragAndDrop>().safePosition = true;
                LeftWeightInPlace = false;
                LeftMass = 0.0f;
                //LeftWeightCollider.enabled = true;

            }

            if(LeftMass > 0.0f)
            {
                StayOnBowl = true;

                SelectedWeightLeft.transform.parent = transform;
                SelectedWeightLeft.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            else{

                StayOnBowl = false;

                SelectedWeightLeft.transform.parent = GameObject.Find("HardMode").transform;
                SelectedWeightLeft.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int x = 1; x < 11; x++)
        {

            if (collision.gameObject.name == "gewicht_" + x.ToString())
            {
                collision.gameObject.GetComponent<DragAndDrop>().safePosition = false;
                if(LeftWeightInPlace == false)
                {
                    LeftWeightInPlace = true;
                    //collision.gameObject.transform.position = this.gameObject.transform.position;

                    SelectedWeightLeft = collision.gameObject;
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
    //             if(collision.gameObject == SelectedWeightLeft)
    //             {
    //                 SelectedWeightLeft = null;
    //             }
    //         }
    //     }
    // }
}
