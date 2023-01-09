using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
  RectTransform _panelTimeUp;
  [SerializeField]
  Button _nextButton;
  [SerializeField]
  Text _correctAnswerText;
  [SerializeField]
  Text _scoreText;

  int _totalScore = 0;

  List<Question> _questions = new List<Question>();
  int _currentIndex = 0;

  [SerializeField]
  float maxAllowableTime = 30.0f;

  IEnumerator _countdownTimerCoroutine;

  // Start is called before the first frame update
  void Start()
  {
    LoadQuestions();
  }

  void LoadQuestions()
  {
    _questions = Question.CreateQuestions();
    ShowQuestion(0);
  }

  void ShowQuestion(int id)
  {
    if (id >= _questions.Count)
    {
      // we have ended answering all the question.
      // go to the post quiz using SceneManager Loadscene..
      return;
    }
    _panelTimeUp.gameObject.SetActive(false);
    _panelQuiz.gameObject.SetActive(true);
    _panelInCorrectAnswer.gameObject.SetActive(false);
    _panelCorrectAnswer.gameObject.SetActive(false);
    _nextButton.gameObject.SetActive(false);

    _currentIndex = id;
    _progressText.text = (_currentIndex + 1).ToString() + "/" + _questions.Count;
    Question q = _questions[id];

    _questionText.text = q.question;

    // TODO: Provide proper validation.
    _optionAText.text = q.choices[0];
    _optionBText.text = q.choices[1];

    // we must have two options. 
    if(q.choices.Count > 2)
      _optionCText.text = q.choices[2];

    if (q.choices.Count > 3)
      _optionDText.text = q.choices[3];

    _countdownTimerCoroutine = Coroutine_CountdownTimer(maxAllowableTime);
    StartCoroutine(_countdownTimerCoroutine);
  }

  IEnumerator Coroutine_CountdownTimer(float t)
  {
    float dt = 0.0f;
    while(dt < t)
    {
      _countdownTimerText.text = (maxAllowableTime - dt).ToString("F2");
      yield return new WaitForSeconds(0.5f);
      dt += 0.5f;
    }
    _countdownTimerText.text = (maxAllowableTime - dt).ToString("F2");

    // Go to: Time over screen
    _panelTimeUp.gameObject.SetActive(true);
    _panelQuiz.gameObject.SetActive(false);
    _panelInCorrectAnswer.gameObject.SetActive(false);
    _panelCorrectAnswer.gameObject.SetActive(false);
    _nextButton.gameObject.SetActive(true);
  }

  // Update is called once per frame
  void Update()
  {

  }

  void SelectOption(int id)
  {
    if(_countdownTimerCoroutine != null)
    {
      StopCoroutine(_countdownTimerCoroutine);
    }

    Question q = _questions[_currentIndex];
    if(id == q.correctAnswerid)
    {
      // correct answer.
      int score = 100;
      ShowCorrectAnswerScreen(score);
    }
    else
    {
      // Incorrect answer.
      ShowIncorrectAnswerScreen();
    }
  }

  void ShowCorrectAnswerScreen(int score)
  {
    _panelTimeUp.gameObject.SetActive(false);
    _panelQuiz.gameObject.SetActive(false);
    _panelInCorrectAnswer.gameObject.SetActive(false);
    _panelCorrectAnswer.gameObject.SetActive(true);
    _nextButton.gameObject.SetActive(true);
    //_scoreText.text = score.ToString();
    _totalScore += score;
    _totalScoreText.text = _totalScore.ToString();

    StartCoroutine(Coroutine_ShowScore(score));
  }

  IEnumerator Coroutine_ShowScore(int score)
  {
    int dt = 0;
    while(dt < score)
    {
      yield return new WaitForSeconds(0.03f);
      dt += 5;
      _scoreText.text = "+" + dt;
    }
    _scoreText.text = score.ToString();
  }

  void ShowIncorrectAnswerScreen()
  {
    _panelTimeUp.gameObject.SetActive(false);
    _panelQuiz.gameObject.SetActive(false);
    _panelInCorrectAnswer.gameObject.SetActive(true);
    _panelCorrectAnswer.gameObject.SetActive(false);
    _nextButton.gameObject.SetActive(true);


    int answerIndex = _questions[_currentIndex].correctAnswerid;
    _correctAnswerText.text = _questions[_currentIndex].choices[answerIndex];
  }

  public void OnClickNext()
  {
  }
  public void OnClickOptionA()
  {
    SelectOption(0);
  }
  public void OnClickOptionB()
  {
    SelectOption(1);
  }
  public void OnClickOptionC()
  {
    SelectOption(2);
  }
  public void OnClickOptionD()
  {
    SelectOption(3);
  }

  public void NextQuestion()
  {
    _currentIndex += 1;
    if(_currentIndex == _questions.Count)
    {
      // finished quiz.
      SceneManager.LoadScene("PostQuiz");
      return;
    }
    ShowQuestion(_currentIndex);
  }
}
