using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;


public class API_LoginScript : MonoBehaviour {

    private const string method_type = "action";

    public static string login_URL = "http://localhost/robot_chef_game/player_api.php?action=login_player";
    public static string register_URL = "http://localhost/robot_chef_game/player_api.php?action=reg_player";

    private static API_LoginScript instance = new API_LoginScript();

    UI_Manager uiScript;
    private API_LoginScript() { }
    // Use this for initialization
    public static API_LoginScript getInstance()
    {
        return instance;
    }

    void Start () {

        uiScript = this.gameObject.GetComponent<UI_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        
        

	}

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }

    public void Network_Request(string RequestType)
    {
        switch (RequestType)
        {
            case "Login":
                StartCoroutine(Login_Users(Player.Player_username, Player.Player_password));
                break;
            case "Register":
                StartCoroutine(Register_Users(Player.Player_name,  Player.Player_username, Player.Player_password));
                break;
        }
    }

    IEnumerator Login_Users(string username , string password)
    {

        WWWForm form = new WWWForm();

        //form.AddField(method_type, "login_user");
        form.AddField("player_username", username);
        form.AddField("player_password", password);
        
        WWW www = new WWW(login_URL, form);

        yield return www;

        if (www.error == null)
        {
                Debug.Log(www.text);

            //string statuscode = JsonHelper.JsonHelper.GetJsonObject(www.text, "statuscode");
            string statuscode =  JSonManager.GetDataFromJSON(www.text, "statuscode");
            string statusMsg = JSonManager.GetDataFromJSON(www.text, "message");

            PlayerDetail_List(JSonManager.GetSpecificDatabjectListFromJSON(www.text , "player"));

            if (statuscode == "2")
            {
                Game.Loggedin_OK = true;
                Debug.Log("Login Success");
                Application.LoadLevel(1);
            }
            else
            {
                Game.Loggedin_OK = false;
                //UI_Manager.getInstance.
                uiScript.ErrorText_Show("Login", statusMsg);
            }

        }
        else
        {
            Debug.Log("Fail : " + www.error);
        }
    }

    IEnumerator Register_Users(string name, string username, string password)
    {

        WWWForm form = new WWWForm();

        //form.AddField(method_type, "login_user");
        form.AddField("player_id", 1);
        form.AddField("player_name", name);
        form.AddField("player_username", username);
        form.AddField("player_password", password);

        WWW www = new WWW(register_URL, form);

        yield return www;

        if (www.error == null)
        {
            Debug.Log(www.text);

            string statuscode = JSonManager.GetDataFromJSON(www.text, "statuscode");
           
            if (statuscode == "3")
            {
                Game.Register_OK= true;
                uiScript.Menu_ButtonCLick("L_login");
               
            }
            else
            {
                Game.Register_OK = false;
                uiScript.ErrorText_Show("Reg", "Username already exist");
            }
            

        }
        else
        {
            Game.Register_OK = false;
            uiScript.ErrorText_Show("Reg", "Error in Register : " + www.error);
           // Debug.Log("Fail : " + www.error);
        }
    }

    void PlayerDetail_List(List<object> PlayerDetails)
    {
        Dictionary<string, object> entry = new Dictionary<string, object>();

        for (int i = 0; i < PlayerDetails.Count; i++)
        {
            entry = (Dictionary<string, object>)PlayerDetails[i];
            string player_id = (string)entry["player_id"];
            string player_name = (string)entry["player_name"];
            string player_username = (string)entry["player_username"];
            string player_total_score = (string)entry["player_total_score"];
            string player_levelCompleted = (string)entry["player_level_completed"];

            Player.Player_id = player_id;
            Player.Player_name = player_name;
            Player.Player_username = player_username;
            Player.Player_total_score = player_total_score;
            Player.Player_current_level = player_levelCompleted;


            //Debug.Log("  Player ID - " + Player.Player_id  + "  Player NAME - " + Player.Player_name  + "  Player USERNAME - " + Player.Player_username);
        }
            

       
    }


   }
