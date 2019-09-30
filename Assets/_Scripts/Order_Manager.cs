using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_Manager : MonoBehaviour {

    public List<GameObject> foodOrderList;

    public Transform TrayOrderPrefab;
    public Transform OrdersPosition;

    public GameObject OnGoing_Order;
    public List<GameObject> Pending_Orders;
    public List<GameObject> Finished_Orders;
    public bool createOrder;

    private static Order_Manager _instance;

    public static Order_Manager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    } 

    // Use this for initialization
    void Start () {
        foodOrderList = new List<GameObject>();
        Pending_Orders = new List<GameObject>();
        Finished_Orders = new List<GameObject>();

        Game.OnGoing_Order = 1;
        OnGoing_Order = null;
        createOrder = false;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject onGoingObj = GameObject.Find("Food_Order " + Game.OnGoing_Order);
        if (Game.OnGoing_Order != 0)
        {
            
            if (onGoingObj)
            {
                OnGoing_Order = onGoingObj;
            }
            //
            
        }

        
        if (!createOrder && Game.OnGoing_Order <= foodOrderList.Count)
        {
            createOrder = true;
            Instaniate_Tray_Order(onGoingObj, Game.OnGoing_Order);

        }

        Create_OrderList();
	}

    void Instaniate_Tray_Order(GameObject order, int orderId)
    {
        GameObject tray_order = Instantiate(TrayOrderPrefab, OrdersPosition).gameObject;
        tray_order.name = "Tray_Order " + orderId;
        tray_order.GetComponent<Tray_Order>().Tray_Order_ID = orderId;

        Create_OrderList();

    }

    void Create_OrderList()
    {
        for (int i = 0; i < 10; i++)
        {

            GameObject orderObject = GameObject.Find("Food_Order " + (i + 1));
            if (orderObject && !foodOrderList.Contains(orderObject))
            {
                foodOrderList.Add(orderObject);
            }
            else
            {
                //   Debug.Log("break");
                break;
            }
        }
    }
}
