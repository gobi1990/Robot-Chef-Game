using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using System;

public class Food : MonoBehaviour {

    public enum FoodType { FoodUI , FoodObject};
    public FoodType foodType = FoodType.FoodUI;

    public string Food_Name;

    public int foodElement_Score;
    private Vector3 food_IntialPosition;
    private Quaternion food_intialRotation;

    [HideInInspector]
    public bool Food_scored;

    //[HideInInspector]
    public bool putOnTray;

    [HideInInspector]
    public bool food_ready;

    public GameObject foodReady_UI;

   // [HideInInspector]
    public float food_pre_time;
    bool OffUI;
    // Use this for initialization
    void Start () {
        if (foodType == FoodType.FoodObject)
        {
            food_IntialPosition = transform.position;
           
            food_intialRotation = transform.rotation;
        }

        if (Food_Name != "Chicken")
        {
            food_ready = true ;
        }
        else {
            food_ready = false;

            
            
        }

        try
        {
            if (Food_Name == "Chicken")
            {
                foodReady_UI.SetActive(false);
            }
        } catch (Exception e)
        {
        }
       
        
	}
	
	// Update is called once per frame
	void Update () {
        if (foodType == FoodType.FoodObject)
        {
         // Debug.Log(this.gameObject.GetComponent<InteractionBehaviour>().closestHoveringControllerDistance);
            try
            {
                if (this.gameObject.GetComponent<InteractionBehaviour>().closestHoveringControllerDistance < 0.3f && putOnTray)
                {
                    
                }
           
      else if (this.gameObject.GetComponent<InteractionBehaviour>().closestHoveringControllerDistance > 0.3f && !putOnTray)
                {
                    ResetRotation();

                    if (transform.position == food_IntialPosition)
                    {
                        CancelInvoke();
                    }
                    else
                    {
                        Invoke("ChangePosition", 2f);
                    }



                }
            }
            catch (NullReferenceException e)
            {

            }
        }

        if (Food_Name == "Chicken")
        {
            if (!OffUI && food_ready)
            {
                foodReady_UI.SetActive(true);
                StartCoroutine(Off_ReadyUI());
                OffUI = true;
            }
        }
        
	}

    void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, food_intialRotation, 2 * Time.deltaTime);
        Invoke("ResetPosition" , 0.5f); 
    }
    void ResetPosition()
    {
        transform.position = Vector3.Lerp(transform.position, food_IntialPosition, 2 * Time.deltaTime);
    }
    void ChangePosition()
    {
        transform.position = food_IntialPosition;
        transform.rotation = food_intialRotation;
    }

    public void Food_Prepairing()
    {

    }

    IEnumerator Off_ReadyUI() {
        yield return new WaitForSeconds(2);
        foodReady_UI.SetActive(false);
    }
   
}
