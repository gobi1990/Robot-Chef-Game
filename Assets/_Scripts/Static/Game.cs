using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game {

    private static bool loggedin_OK;
    private static bool register_OK;

    private static int score;
    private static bool gameOver;

    private static int onGoing_Order;

    private static int level_id;

    public static bool Loggedin_OK
    {
        get
        {
            return loggedin_OK;
        }

        set
        {
            loggedin_OK = value;
        }
    }

    public static bool Register_OK
    {
        get
        {
            return register_OK;
        }

        set
        {
            register_OK = value;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public static bool GameOver
    {
        get
        {
            return gameOver;
        }

        set
        {
            gameOver = value;
        }
    }

    public static int OnGoing_Order
    {
        get
        {
            return onGoing_Order;
        }

        set
        {
            onGoing_Order = value;
        }
    }

    public static int Level_id
    {
        get
        {
            return level_id;
        }

        set
        {
            level_id = value;
        }
    }
}
