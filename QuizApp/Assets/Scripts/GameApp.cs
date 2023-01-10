using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class GameApp : Patterns.Singleton<GameApp>
{
  public AudioSource audioSource;
  public User user { get; private set; }

  public string userFilename = "/user.json";
  public string userResponsesFilename = "/user_responses.json";

  // Start is called before the first frame update
  void Start()
  {
    user = new User();
    LoadUserData();
    SceneManager.LoadScene("PreQuiz");
  }

  void LoadUserData()
  {
    // Load the data.
    string path = Application.persistentDataPath + userFilename;
    if (File.Exists(path))
    {
      string str = File.ReadAllText(path);

      JSONNode n = JSON.Parse(str);
      user.FromJson(n);
    }
  }

  public void SaveUserData()
  {
    string path = Application.persistentDataPath + userFilename;
    File.WriteAllText(path, user.ToJson().ToString());
  }

  public void SaveResponses(List<Response> responses)
  {
    string path = Application.persistentDataPath + userResponsesFilename;
    string str = Response.ToJson(responses).ToString();
    File.WriteAllText(path, str);
  }
}
