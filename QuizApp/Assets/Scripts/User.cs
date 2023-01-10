using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
  public string name = "johndoe";
  public string email = "example@email.com";
  public int score = 0;
  public int level = 0;

  public virtual JSONNode ToJson()
  {
    JSONNode n = new JSONObject();
    n["name"] = name;
    n["email"] = email;
    n["score"] = score;
    n["level"] = level;
    return n;
  }

  public virtual void FromJson(JSONNode n)
  {
    name = n["name"];
    email = n["email"];
    score = n["score"].AsInt;
    level = n["level"].AsInt;
  }
}
