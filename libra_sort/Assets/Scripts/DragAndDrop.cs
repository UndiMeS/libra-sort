using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    public bool selected;
    GameObject left_bowl;
    GameObject right_bowl;
    public Vector3 PickUpPosition;
    bool newValue;

    public bool safePosition;

    PolygonCollider2D weight_collider;
    // Start is called before the first frame update
    void Start()
    {
        weight_collider = this.GetComponent<PolygonCollider2D>();
        
        left_bowl = GameObject.Find("left_collider");
        right_bowl = GameObject.Find("right_collider");
    }

    // Update is called once per frame
    void Update()
    {

        if(selected == true){
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            
            
            if(cursorPos.y < -3.15F){
                transform.position= new Vector2(cursorPos.x, -3.15F);
            }
            else{
            transform.position = new Vector2(cursorPos.x, cursorPos.y);

            }
            //weight_collider.enabled = !weight_collider.enabled;
        }

        if(Input.GetMouseButtonUp(0)){
            // if(weight_collider.enabled != null){
            //     newValue = weight_collider.enabled;
            //         if(newValue != weight_collider.enabled)
            //             weight_collider.enabled = newValue;
            //     weight_collider.enabled = true;
            // }

            if(weight_collider.enabled == false)
            {
                weight_collider.enabled = true;
            }
            else
                return;

            
            
            selected = false;
            //weight_collider.enabled = weight_collider.enabled;
            // left_bowl.GetComponent<BoxCollider2D>().enabled = true;
            // right_bowl.GetComponent<BoxCollider2D>().enabled = true;
            //weight_collider.enabled = true;

        }
        
    }

    void OnMouseOver(){

        if(Input.GetMouseButtonDown(0)){
            selected = true;
            // left_bowl.GetComponent<BoxCollider2D>().enabled = false;
            // right_bowl.GetComponent<BoxCollider2D>().enabled = false;

            if(safePosition == true)
            {
                PickUpPosition = this.gameObject.transform.position;
            }
            
            weight_collider.enabled = false;
        }
    }
}
