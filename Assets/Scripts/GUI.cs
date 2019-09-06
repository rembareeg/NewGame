using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStates;

public class GUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameMenuScreen, _gameEndScreen, _settingsButton;
    [SerializeField]
    private Sprite _yellowStar;

    private void Awake()
    {
        GameLogic.Instance.EnableMenuScreen += EnableMenuScreen;
        GameLogic.Instance.EnableEndScreen += EnableEndScreen;
    }

    public void Pause()
    {
        GameLogic.Instance.GameState = GameState.Paused;
    }

    public void Play()
    {
        GameLogic.Instance.GameState = GameState.Spawning;
    }

    private void EnableMenuScreen()
    {
        _gameEndScreen.SetActive(false);
        _gameMenuScreen.SetActive(true);
        _settingsButton.SetActive(true);
    }

    private void EnableEndScreen(int starsCount)
    {
        EndScreen endScreen = _gameEndScreen.GetComponent<EndScreen>();
        _gameMenuScreen.GetComponent<RectTransform>().offsetMin = new Vector2(0, 108); // new Vector2(left, bottom);
        _gameMenuScreen.GetComponent<RectTransform>().offsetMax = new Vector2(0, -108); // new Vector2(-right, -top);
        if (starsCount == 1)
        {
            endScreen.Star1.sprite = _yellowStar;
        }
        else if (starsCount == 2)
        {
            endScreen.Star1.sprite = _yellowStar;
            endScreen.Star2.sprite = _yellowStar;
        }
        else if (starsCount == 3)
        {
            endScreen.Star1.sprite = _yellowStar;
            endScreen.Star2.sprite = _yellowStar;
            endScreen.Star3.sprite = _yellowStar;
        }
        else
        {

        }
        
        _gameMenuScreen.SetActive(false);
        _gameEndScreen.SetActive(true);
        _settingsButton.SetActive(false);
    }

    public void ContinueLevel()
    {
        GameLogic.Instance.GameState = GameStates.GameState.Paused;
    }

    public void ExitLevel()
    {
        GameLogic.Instance.EnableMenuScreen -= EnableMenuScreen;
        GameLogic.Instance.EnableEndScreen -= EnableEndScreen;
        SceneManager.LoadScene(0);
    }

    public void SettingsButton()
    {

    }

}
