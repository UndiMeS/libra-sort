using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate_prefab_Hard : MonoBehaviour
{
    public GameObject prefab;
    GameObject weights;
    //public get_mass gewicht;
    GameObject gewicht;
    int Length = 11;
    int Rand;
    List<int> list = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        list = new List<int>(new int[11]);
        for (int i = 1; i < 11; i++)
        {
            weights = Instantiate(prefab, new Vector3(-18.7f + (i * 1.25F), -2.0F, 0), Quaternion.identity);
            weights.name = "gewicht_" + i.ToString();
            weights.transform.parent = GameObject.Find("HardMode").transform;
            //weights.mass = i;
            //weights.GetComponent<get_mass>().mass = (float)i;
            //gewicht.mass = i;
            
        //for (int j = 1; j < Length; j++)
        //{
            Rand = Random.Range(1,11);
            while (list.Contains(Rand))
            {
                Rand = Random.Range(1,11);
            }
            list[i] = Rand;
            print(list[i]);
        //}
        weights.GetComponent<get_mass>().mass = (float)Rand;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
