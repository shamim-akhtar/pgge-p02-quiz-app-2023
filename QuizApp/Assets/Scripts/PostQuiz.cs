using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostQuiz : MonoBehaviour
{
  [SerializeField]
  Text _totalScoreText;
  [SerializeField]
  Text _levelText;

  public void OnClickPlay()
  {
    SceneManager.LoadScene("Quiz");
  }
}
