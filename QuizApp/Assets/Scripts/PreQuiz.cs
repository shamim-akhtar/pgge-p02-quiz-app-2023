using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreQuiz : MonoBehaviour
{
  public void OnClickPlay()
  {
    SceneManager.LoadScene("Quiz");
  }
}
