                                                                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(API_LoginScript))]
public class UI_Manager : MonoBehaviour {

    [SerializeField]
    private GameObject[] UI_Menus;
    [SerializeField]
    private InputField[] Login_Fields;
    [SerializeField]
    private InputField[] Register_Fields;
    [SerializeField]
    private Text[] ErrorTexts;

    API_LoginScript networkScript;

    
    // Use this for initialization
    
    // Use this for initialization
    void Start() {
        OffUI_Menus();
        UI_Menus[2].SetActive(true);
        OffErrorText();

        StartCoroutine(OffTitle());

        networkScript = this.GetComponent<API_LoginScript>();


    }


    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.R))
        {
          //  Application.LoadLevel(0);
        }

    }


    ///////////////////////////// LOGIN FORM /////////////////////////////
    public void LoginButton_Click()
    {
        if (Login_Fields[0].text.Length > 0 && Login_Fields[1].text.Length > 0)
        {
            Player.Player_username = Login_Fields[0].text;
            Player.Player_password = Login_Fields[1].text;
            networkScript.Network_Request("Login");

            // API_LoginScript.getInstance().Network_Request("Login");
        }
        else {
            ErrorText_Show("Login" , "Enter valid username and password");
        }

    }


    /// //////////////////////Player Register ///////////////////////
    public void RegisterButton_Click()
    {
        if (Register_Fields[0].text.Length > 0 && Register_Fields[1].text.Length > 0 && Register_Fields[2].text.Length > 0 && Register_Fields[3].text.Length > 0)
        {

            if (Register_Fields[2].text == Register_Fields[3].text)
            {
                Player.Player_name = Register_Fields[0].text;
                Player.Player_username = Register_Fields[1].text;
                Player.Player_password = Register_Fields[2].text;
                networkScript.Network_Request("Register");
            }
            else {
                ErrorText_Show("Reg", "Check your password again");
            }
            
            //  API_LoginScript.getInstance().Network_Request("Register");
        }
        else {
            ErrorText_Show("Reg", "Enter valid details");
        }

    }

    public void Menu_ButtonCLick(string menuType)
    {
        OffUI_Menus();
        switch (menuType)
        {
            case "L_login":
                UI_Menus[0].SetActive(true);
                foreach(InputField t in Register_Fields)
                {
                    t.text = "";
                }
                break;
            case "L_register":
                UI_Menus[1].SetActive(true);
                break;

        }


    }

    void OffUI_Menus()
    {
        foreach (GameObject go in UI_Menus)
        {
            go.SetActive(false);
        }
    }

    public void ErrorText_Show(string errorType , string errorMsg)
    {
        if (errorType == "Login")
        {
            ErrorTexts[0].gameObject.SetActive(true);
            ErrorTexts[0].text = errorMsg;
        }
        else if (errorType == "Reg")
        {
            ErrorTexts[1].gameObject.SetActive(true);
            ErrorTexts[1].text = errorMsg;
        }
        Invoke("OffErrorText" , 2);
    }

    void OffErrorText()
    {
        foreach (Text go in ErrorTexts)
        {
            go.gameObject.SetActive(false);
        }
    }

    IEnumerator OffTitle()
    {
        yield return new WaitForSeconds(2);
        UI_Menus[2].SetActive(false);
        UI_Menus[0].SetActive(true);
    }
}
