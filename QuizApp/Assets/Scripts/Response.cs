using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public enum ResponseType
{
  CORRECT,
  INCORRECT,
  NOT_ATTEMPTED,
}
public class Response
{
  public string question_id = "";
  public ResponseType responseType = ResponseType.NOT_ATTEMPTED;
  public float time = 0.0f;


  public virtual JSONNode ToJson()
  {
    JSONNode n = new JSONObject();
    n["question_id"] = question_id;
    n["responseType"] = (int)responseType;
    n["time"] = time;
    return n;
  }

  public virtual void FromJson(JSONNode n)
  {
    question_id = n["question_id"];
    responseType = (ResponseType)(n["responseType"].AsInt);
    time = n["time"].AsInt;
  }

  static public JSONNode ToJson(List<Response> responses)
  {
    JSONNode n = new JSONObject();
    JSONArray a = new JSONArray();

    for(int i = 0; i < responses.Count; ++i)
    {
      a.Add(responses[i].ToJson());
    }

    n["responses"] = a;
    return n;
  }
}
