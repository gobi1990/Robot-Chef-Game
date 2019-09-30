using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook_Trigger : MonoBehaviour {

    
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Food")
        {
            if (col.GetComponent<Food>().Food_Name == "Chicken")
            {
                col.GetComponent<Animator>().enabled = true;

                StartCoroutine(Food_Cooking_Time(col.gameObject));
            }
        }
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Food")
        {
            if (col.GetComponent<Food>().Food_Name == "Chicken")
            {

                col.transform.rotation = Quaternion.Euler(0, 0, 0);

                if (!col.GetComponent<Food>().putOnTray)
                {
                    col.GetComponent<Food>().putOnTray = true;
                }

                
            }

            
            // col.GetComponent<InteractionBehaviour>().enabled = false;


        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Food")
        {
            if (col.GetComponent<Food>().Food_Name == "Chicken")
            {
                col.GetComponent<Animator>().enabled = false;
                col.GetComponent<Food>().putOnTray = false;
            }
        }
    }

    IEnumerator Food_Cooking_Time(GameObject foodObj)
    {
        if (foodObj.GetComponent<Food>().food_pre_time < 4)
        {
            foodObj.GetComponent<Food>().food_pre_time++;
            yield return new WaitForSeconds(1);
            StartCoroutine(Food_Cooking_Time(foodObj));
        }
        else {
            Food_Prepared(foodObj);
        }

        
       
    }

    void Food_Prepared(GameObject foodObj)
    {
        
        foodObj.GetComponent<Food>().food_ready = true;
    }
}