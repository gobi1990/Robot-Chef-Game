using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player  {

    private static string player_id;
    private static string player_name;
    private static string player_username;
    private static string player_password;
    private static string player_current_level;
    private static string player_total_score;

    public static string Player_id
    {
        get
        {
            return player_id;
        }

        set
        {
            player_id = value;
        }
    }

    public static string Player_name
    {
        get
        {
            return player_name;
        }

        set
        {
            player_name = value;
        }
    }

    public static string Player_username
    {
        get
        {
            return player_username;
        }

        set
        {
            player_username = value;
        }
    }

    public static string Player_password
    {
        get
        {
            return player_password;
        }

        set
        {
            player_password = value;
        }
    }

    public static string Player_total_score
    {
        get
        {
            return player_total_score;
        }

        set
        {
            player_total_score = value;
        }
    }

    public static string Player_current_level
    {
        get
        {
            return player_current_level;
        }

        set
        {
            player_current_level = value;
        }
    }
}
