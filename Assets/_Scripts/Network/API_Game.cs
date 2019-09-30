using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API_Game : MonoBehaviour {

    private const string method_type = "action";

    public static string leaderBoard_URL = "http://localhost/robot_chef_game/game_api.php?action=leaderBoard_Score";

    public GameObject[] leaderBoard_UI_Objs;
    
    private static API_Game instance;

    public static API_Game Instance
    {
        get
        {
            return instance;
        }
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void LeaderBoardButton_Click()
    {
        StartCoroutine(Players_LeaderBoard());
    }


    IEnumerator Players_LeaderBoard()
    {

        WWWForm form = new WWWForm();
        
        WWW www = new WWW(leaderBoard_URL, form);

        yield return www;

        if (www.error == null)
        {
          //  Debug.Log(www.text);

            string statuscode = JSonManager.GetDataFromJSON(www.text, "statuscode");
            //string statuscode = 
            //string statusMsg = JSonManager.GetDataFromJSON(www.text, "message");

            //PlayerDetail_List(JSonManager.GetSpecificDatabjectListFromJSON(www.text, "player"));

            if (statuscode == "2" )
            {
                LeaderBoardPlayer_List(JSonManager.GetSpecificDatabjectListFromJSON(www.text, "top_players"));
            }
            else
            {
                Debug.Log("None");
            }

        }
        else
        {
            Debug.Log("Fail : " + www.error);
        }
    }

    void LeaderBoardPlayer_List(List<object> playersList)
    {
        
        Dictionary<string, object> entry = new Dictionary<string, object>();

        entry.Clear();
       
        
        for (int i = 0; i < playersList.Count; i++)
        {
            entry = (Dictionary<string, object>)playersList[i];

            
            string player_id = (string)entry["player_id"];
            string player_username = (string)entry["player_username"];
            string player_score = (string)entry["player_total_score"];
            string player_rank = (string)entry["player_rank"].ToString();

            
                if (player_rank == leaderBoard_UI_Objs[i].GetComponent<LeaderBoard_Player_UI>().player_rank.ToString())
                {
                   // LeaderBoard_Players_Update(player_username , player_score);

                   leaderBoard_UI_Objs[i].GetComponent<LeaderBoard_Player_UI>().player_username = player_username;
                    leaderBoard_UI_Objs[i].GetComponent<LeaderBoard_Player_UI>().player_score = player_score;
            }
           
            Debug.Log("Player Rank : " + player_rank + "Player Username  : " + player_username + "Player Score : " + player_score );

        }

    }

    void LeaderBoard_Players_Update(string username , string score)
    {
        for (int i=0;i< leaderBoard_UI_Objs.Length;i++)
        {
            leaderBoard_UI_Objs[i].GetComponent<LeaderBoard_Player_UI>().player_username = username;
            leaderBoard_UI_Objs[i].GetComponent<LeaderBoard_Player_UI>().player_score = score;
        }     
    }
}
