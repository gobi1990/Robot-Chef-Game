using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API_Player : MonoBehaviour {

    public static string profile_URL = "http://localhost/robot_chef_game/player_api.php?action=player_profile";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Profile_Request()
    {
        Player_Profile_API_Request(Player.Player_username);
    }

    IEnumerator Player_Profile_API_Request(string username)
    {

        WWWForm form = new WWWForm();

        //form.AddField(method_type, "login_user");
        form.AddField("player_username", username);

        WWW www = new WWW(profile_URL, form);

        yield return www;

        if (www.error == null)
        {
            Debug.Log(www.text);

            //string statuscode = JsonHelper.JsonHelper.GetJsonObject(www.text, "statuscode");
            string statuscode = JSonManager.GetDataFromJSON(www.text, "statuscode");
           // string statusMsg = JSonManager.GetDataFromJSON(www.text, "message");

            PlayerDetail_List(JSonManager.GetSpecificDatabjectListFromJSON(www.text, "player"));

            if (statuscode == "2")
            {
               
                
              
            }
            else
            {
               
               
            }

        }
        else
        {
            Debug.Log("Fail : " + www.error);
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
