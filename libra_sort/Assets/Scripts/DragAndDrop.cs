using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool selected;

    PolygonCollider2D weight_collider; 
    // Start is called before the first frame update
    void Start()
    {
        weight_collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(selected == true){
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
            //weight_collider.enabled = !weight_collider.enabled;
        }

        if(Input.GetMouseButtonUp(0)){
            selected = false;
            //weight_collider.enabled = weight_collider.enabled;
        }
        
    }

    void OnMouseOver(){

        if(Input.GetMouseButtonDown(0)){
            selected = true;
        }
    }
}
