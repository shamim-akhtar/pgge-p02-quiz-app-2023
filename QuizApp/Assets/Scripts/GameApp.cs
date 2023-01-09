using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApp : Patterns.Singleton<GameApp>
{
  public AudioSource audioSource;
  // Start is called before the first frame update
  void Start()
  {
    SceneManager.LoadScene("PreQuiz");
  }
}
