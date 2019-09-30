using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MiniJSON;

public static class JSonManager
{

    public static string GetDataFromJSON(string JSONString, string JSONAttr)
    {

        string currentAttrData = "";

        Dictionary<string, System.Object> JSONReader = new Dictionary<string, System.Object>();

        JSONReader = Json.Deserialize(JSONString) as Dictionary<string, System.Object>;

        currentAttrData = JSONReader[JSONAttr] as String;
                 
        return currentAttrData;

    }




    public static List<object> GetSpecificDatabjectListFromJSON(string JSONString, string JSONObjectName)
    {
        Dictionary<string, object> JObject = Json.Deserialize(JSONString) as Dictionary<string, object>;

        object OutJObject;

        List<object> JObjectData = new List<object>();

        if (JObject.TryGetValue(JSONObjectName, out OutJObject))
        {
            JObjectData = (List<object>)OutJObject;
        }

        return JObjectData;


    }

}
