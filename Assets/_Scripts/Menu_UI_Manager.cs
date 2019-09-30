using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu_UI_Manager : MonoBehaviour {

    [SerializeField]
    private GameObject[] Menu_Objects;
    [SerializeField]
    private Text userNameText;

    [SerializeField]
    private Text ProfileUI_Useraname;
    [SerializeField]
    private Text ProfileUI_Score;
    [SerializeField]
    private Text ProfileUI_Level;
    // Use this for initialization
    void Start () {
        OffMenuObjects();
        Menu_Objects[0].SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        userNameText.text = Player.Player_username;

        Profile_Menu_UI();

    }

    public void MainMenu_Button_Click(string ButtonName)
    {
        //OffMenuObjects();
        switch (ButtonName)
        {
            case "play":
                Application.LoadLevel(2);
                break;
            case "setting":
                Menu_Objects[0].SetActive(true);
                break;
            case "leaderboard":
               OffMenuObjects();
                Menu_Objects[1].SetActive(true);
                break;
            case "profile":
                OffMenuObjects();
                Menu_Objects[3].SetActive(true);
                break;
            case "back":
                OffMenuObjects();
                Menu_Objects[0].SetActive(true);
                break;
            case "logout":
                Application.LoadLevel(0);
                break;
            case "levels":
                OffMenuObjects();
                Menu_Objects[2].SetActive(true);
                break;

        }

    }

    void OffMenuObjects()
    {
        for (int i =0; i< Menu_Objects.Length;i++)
        {
            Menu_Objects[i].SetActive(false);
        }
    }

    void Profile_Menu_UI()
    {
        ProfileUI_Useraname.text = Player.Player_username;

        if (Player.Player_total_score == null)
        {
            ProfileUI_Score.text = "0";
        } else
           {
            ProfileUI_Score.text = Player.Player_total_score.ToString();
        }
        

        if (Player.Player_current_level == null)
        {
            ProfileUI_Level.text = "0";
        }
        else {
            ProfileUI_Level.text = Player.Player_current_level.ToString();
        }
       

    }
}
