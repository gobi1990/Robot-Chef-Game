using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class Tray_Trigger : MonoBehaviour {

    public bool objectStay;
    private Transform parentTransform;
    // Use this for initialization
    void Start()
    {
        objectStay = false;
        parentTransform = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Food")
        {
         //   if (col.GetComponent<Food>().Food_Name == "Chicken")
         //   {
                if (col.GetComponent<Food>().food_ready)
            {
                objectStay = true;
                if (objectStay)
                {
                    objectStay = false;
                    transform.parent.GetComponent<Tray_Order>().player_order_foods.Add(col.GetComponent<Food>().Food_Name);
                    if (!col.GetComponent<Food>().Food_scored)
                    {
                        col.GetComponent<Food>().Food_scored = true;
                        Game.Score += col.GetComponent<Food>().foodElement_Score;
                    }


                }
            }
        //    }
            else {

            }
           

        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Food")
        {
           
                
            col.transform.rotation = Quaternion.Euler(0,0,0);

            if (!col.GetComponent<Food>().putOnTray)
            {
                col.GetComponent<Food>().putOnTray = true;
              col.transform.parent = parentTransform;
                col.GetComponent<Animator>().enabled = false;
               
            }
            
           // col.GetComponent<InteractionBehaviour>().enabled = false;


        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Food")
        {
           
            col.GetComponent<Food>().putOnTray = false;
           transform.parent.GetComponent<Tray_Order>().player_order_foods.Remove(col.GetComponent<Food>().Food_Name);

            col.transform.parent = GameObject.Find("Foods").transform;
        }
    }



}
