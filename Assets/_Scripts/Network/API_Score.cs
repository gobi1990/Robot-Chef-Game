using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API_Score : MonoBehaviour {

    public static string Score_Update_URL = "http://localhost/robot_chef_game/player_api.php?action=player_score";

    public static string Level_Score_URL = "http://localhost/robot_chef_game/level_api.php?action=level_score";

    bool scoreUpdated;

    // Use this for initialization
    void Start () {

        scoreUpdated = false;
    }
    void OnEnable()
    {
        scoreUpdated = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Game.GameOver && !scoreUpdated)
        {
            int TotalScore;
            TotalScore = int.Parse(Player.Player_total_score) + Game.Score;
            Player.Player_total_score = TotalScore.ToString();


            scoreUpdated = true;
           // LevelScoreUpdate();
            UpdateScore();

            
        }
	}
    public void LevelScoreUpdate()
    {
        Level_Score_Update(Game.Level_id , int.Parse(Player.Player_id) , Game.Score.ToString() , null);
    }

    IEnumerator Level_Score_Update(int levelId, int playerId , string levelScore , string levelTime)
    {

        WWWForm form = new WWWForm();

        //form.AddField(method_type, "login_user");
        form.AddField("player_id", playerId);
        form.AddField("level_id", levelId);
        form.AddField("player_level_score", levelScore);
        form.AddField("player_level_time", levelTime);

        WWW www = new WWW(Score_Update_URL, form);

        yield return www;

        if (www.error == null)
        {
            Debug.Log(www.text);

            //string statuscode = JsonHelper.JsonHelper.GetJsonObject(www.text, "statuscode");
            string statuscode = JSonManager.GetDataFromJSON(www.text, "statuscode");
            string statusMsg = JSonManager.GetDataFromJSON(www.text, "message");

            if (statuscode == "2")
            {
                Debug.Log(statusMsg);
            }
            else
            {
                Debug.Log(statusMsg);
            }

        }
        else
        {
            Debug.Log("Fail : " + www.error);
        }
    }

    void UpdateScore()
    {
        StartCoroutine(Score_Update(Player.Player_username , Player.Player_total_score));
    }
    IEnumerator Score_Update(string username, string score)
    {

        WWWForm form = new WWWForm();

        //form.AddField(method_type, "login_user");
        form.AddField("player_username", username);
        form.AddField("player_score" , score);

        WWW www = new WWW(Score_Update_URL, form);

        yield return www;

        if (www.error == null)
        {
            Debug.Log(www.text);

            //string statuscode = JsonHelper.JsonHelper.GetJsonObject(www.text, "statuscode");
            string statuscode = JSonManager.GetDataFromJSON(www.text, "statuscode");
            string statusMsg = JSonManager.GetDataFromJSON(www.text, "message");
            
            if (statuscode == "2")
            {
                Debug.Log(statusMsg);
            }
            else
            {
                Debug.Log(statusMsg);
            }

        }
        else
        {
            Debug.Log("Fail : " + www.error);
        }
    }
}
