using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficult_Ground_collider : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gewicht;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         for (int x = 1; x < 11; x++)
        {

            if (collision.gameObject.name == "difficult_gewicht_" + x.ToString())
            {
                gewicht = GameObject.Find("difficult_gewicht_" + x.ToString());
                gewicht.transform.position = new Vector3(gewicht.transform.position.x,-275.4F, 0.0F);
            }
        }
    }
}
