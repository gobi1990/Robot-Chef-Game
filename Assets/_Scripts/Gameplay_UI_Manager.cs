using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay_UI_Manager : MonoBehaviour {

    public Text timeText;
    public Text levelText;
    bool GameStart;

    [SerializeField]
    private float gameStartTime;
    public Text score_Text;

    [SerializeField]
    private GameObject[] Game_UI_Menus;

    public Text GameOverUI_Score;
    public Text GameOverUI_Orders;
    public Text GameOverUI_username;

    public int GameLevel_Id;

    public int GameLevel_ScoreLimit;

    public Text GameLevelError;
    // Use this for initialization
    void Start() {


    }

    void OnEnable()
    {
        GameStart = true;
        Game.GameOver = false;
        GameLevelError.gameObject.SetActive(false);

        levelText.gameObject.SetActive(true);
        StartCoroutine(OffLevelText());

        if (GameStart)
        {
            Invoke("TimeChange", 1);
            timeText.text = Mathf.Round(gameStartTime).ToString("00");
        }
        Game.Score = 0;

        Game.Level_id = GameLevel_Id;
    }

    // Update is called once per frame
    void Update() {

        if (GameStart)
        {
            timeText.text = Mathf.Round(gameStartTime).ToString("00");
            score_Text.text = Game.Score.ToString("00");
        }


        if (gameStartTime <= 0)
        {
            GameStart = false;
            Game.GameOver = true;
        }

        if (Game.GameOver)
        {
            Off_Game_UI_Menus();
            Game_UI_Menus[0].SetActive(true);

            GameOverUI_username.text = Player.Player_username;

            if (Player.Player_total_score == null)
            {
                GameOverUI_Score.text = "0";
            }
            else {
                GameOverUI_Score.text = Player.Player_total_score.ToString();
            }
            
            //GameOverUI_Orders.text = 
        }

    }

    void TimeChange()
    {
        gameStartTime -= 1;
        Invoke("TimeChange", 1);
    }

    void Off_Game_UI_Menus()
    {
        foreach (GameObject go in Game_UI_Menus)
        {
            go.SetActive(false);
        }
    }

    public void RestartButton_Click()
    {
        Application.LoadLevel(2);
    }

    public void MainMenuButton_Click()
    {
        Application.LoadLevel(1);
    }

    public void NextLevel_Button()
    {
        if (Player.Player_total_score == null)
        {
            Player.Player_total_score = "0";
        }
        Debug.Log(int.Parse(Player.Player_total_score));
        if (int.Parse(Player.Player_total_score) > 0)
        {
            if (int.Parse(Player.Player_total_score) >= GameLevel_ScoreLimit)
            {
                Debug.Log("Next level");
                Application.LoadLevel(GameLevel_Id + 2);
            }
            else {

                GameLevelError.gameObject.SetActive(true);
                GameLevelError.text = "You need to get more than " + GameLevel_ScoreLimit.ToString(); 
                StartCoroutine(OffError());

            }



        }

    }

    IEnumerator OffError()
    {
        yield return new WaitForSeconds(2);
        GameLevelError.gameObject.SetActive(false);
    }

    IEnumerator OffLevelText()
    {
        yield return new WaitForSeconds(1);
        levelText.gameObject.SetActive(false);
    }
}
