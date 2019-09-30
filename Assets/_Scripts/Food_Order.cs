using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Food_Order : MonoBehaviour {

    public int order_ID;
    public float Order_Time;
    [HideInInspector]
    public float Order_CurrentTime;

    public string[] Order_Foods;

    bool increaseOrderId;

    //public Text OrderTime_TextUI;
    [SerializeField]
    private Image OrderTimeCircleImage;
	// Use this for initialization
	void Start () {
        Order_Foods = new string[this.transform.childCount];
        Order_CurrentTime = Order_Time;

        try {
            for (int i = 0; i < transform.childCount; i++)
            {
                Order_Foods[i] = transform.GetChild(i).GetComponent<Food>().Food_Name;
            }
        }
        catch (NullReferenceException e) {

        }

        increaseOrderId = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Order_Time > 0)
        {
            //OrderTime_TextUI.text = Order_Time.ToString("00");
            OrderTimeCircleImage.fillAmount = Order_CurrentTime / Order_Time;
            Invoke("OrderTimeDecrease", 1f);
        }

        if (Order_CurrentTime <=0)
        {
            //

          //  Debug.Log("Decreses");
            if (!increaseOrderId)
            {
                
                Order_Manager.Instance.createOrder = false;
                increaseOrderId = true;
               
                Game.OnGoing_Order++;

                StartCoroutine(OffParent());

            }
        }
        

	}

    void OrderTimeDecrease()
    {
        Order_CurrentTime-= Time.deltaTime;
    }

    IEnumerator OffParent()
    {
        yield return new WaitForSeconds(2);
        this.transform.parent.gameObject.SetActive(false);
    }
}
