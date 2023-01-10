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

  private void Start()
  {
    _totalScoreText.text = GameApp.Instance.user.score.ToString();
    _levelText.text = GameApp.Instance.user.level.ToString();
  }

  public void OnClickPlay()
  {

    SceneManager.LoadScene("Quiz");
  }
}
