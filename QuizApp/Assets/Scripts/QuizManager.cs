using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
  [SerializeField]
  Text _totalScoreText;
  [SerializeField]
  Text _countdownTimerText;
  [SerializeField]
  Text _progressText;
  [SerializeField]
  Text _questionText;
  [SerializeField]
  Text _optionAText;
  [SerializeField]
  Text _optionBText;
  [SerializeField]
  Text _optionCText;
  [SerializeField]
  Text _optionDText;

  [SerializeField]
  RectTransform _panelQuiz;
  [SerializeField]
  RectTransform _panelCorrectAnswer;
  [SerializeField]
  RectTransform _panelInCorrectAnswer;
  [SerializeField]
  Button _nextButton;
  [SerializeField]
  Text _correctAnswerText;
  [SerializeField]
  Text _scoreText;

  List<Question> _questions;

  // Start is called before the first frame update
  void Start()
  {
    LoadQuestions();
  }

  void LoadQuestions()
  {
    _questions = Question.CreateQuestions();
  }

  void ShowQuestion(int id)
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnClickNext()
  {

  }
  public void OnClickOptionA()
  {

  }
  public void OnClickOptionB()
  {

  }
  public void OnClickOptionC()
  {

  }
  public void OnClickOptionD()
  {

  }
}
