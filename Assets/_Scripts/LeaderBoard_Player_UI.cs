using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard_Player_UI : MonoBehaviour {

    public int player_rank;
    [HideInInspector]
    public string player_username;
    [HideInInspector]
    public string player_score;

    public Text player_username_UI;

    public Text player_score_UI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        player_username_UI.text = player_username;
        player_score_UI.text = player_score;
	}
}
