using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tray_Order : MonoBehaviour {

    public int Tray_Order_ID;
    public string[] order_foods;

    [SerializeField]
    private int Order_ScorePoint;

    public List<string> player_order_foods;

    public List<string> pending_foods;

    private bool orderScored;
    [SerializeField]
    private Text OrderNumber_Text;

	// Use this for initialization
	void Start () {

        
	}

    void OnEnable()
    {
        orderScored = false;
        foreach (string str in order_foods)
        {
            pending_foods.Add(str);
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!Game.GameOver)
        {
            GameObject orderObject = GameObject.Find("Food_Order " + Tray_Order_ID);

            try {
                if (orderObject.GetComponent<Food_Order>().Order_Time > 0)
                {
                    order_foods = orderObject.GetComponent<Food_Order>().Order_Foods;
                }
                else
                {
                }

                if (orderObject.GetComponent<Food_Order>().Order_CurrentTime <= 0)
                {
                    this.gameObject.GetComponent<Animator>().SetBool("timeOut", true);

                    try
                    {

                        //for (int i = 0; i < order_foods.Length; i++)
                        //{
                        //    for (int j = 0; j < player_order_foods.Count; j++)
                        //    {
                        //        if (order_foods[i] == player_order_foods[j])
                        //        {
                        //            if (!orderScored)
                        //            {
                        //                //   orderScored = true;
                        //                // Game.Score += Order_ScorePoint;
                        //            }
                        //            //  

                        //        }
                        //        else
                        //        {
                        //            // Debug.Log("ORDER NOT MATCHING............." + order_foods[i]);
                        //            return;

                        //        }
                        //    }

                        //}
                    }
                    catch (ArgumentOutOfRangeException e)
                    {

                    }
                }


                OrderNumber_Text.text = orderObject.name.Remove(0, 5);
            } catch (Exception e)
            {

            }
            
           

            

           

        }
        
        
    }
}
