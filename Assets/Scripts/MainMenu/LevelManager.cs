using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField]
    private string _levelFolder;
    [SerializeField]
    private GameObject _levelButtonObject;
    [SerializeField]
    private Sprite _yellowStar;
    [SerializeField]
    private Level[] _levelList;
    


    // Start is called before the first frame update
    void Awake()
    {
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillList()
    {
        for (int i = 0; i < _levelList.Length; i++)
        {
            Level level = _levelList[i];
            LevelButton button = Instantiate(_levelButtonObject, transform).GetComponent<LevelButton>();
            if (PlayerPrefs.HasKey(level.SceneName + "Stars"))
            {
                int starsCount = int.Parse(PlayerPrefs.GetString(level.SceneName + "Stars"));
                _levelList[i].Stars = starsCount;
                if (starsCount == 1)
                {
                    button.Star1.sprite = _yellowStar;
                }
                else if (starsCount == 2)
                {
                    button.Star1.sprite = _yellowStar;
                    button.Star2.sprite = _yellowStar;
                }
                else if (starsCount == 3)
                {
                    button.Star1.sprite = _yellowStar;
                    button.Star2.sprite = _yellowStar;
                    button.Star3.sprite = _yellowStar;
                }
                else
                {

                }

            }
            else
            {
                PlayerPrefs.SetString(level.SceneName + "Stars", "0");
            }
            
            button.LevelText.text = _levelList[i].LevelNumber;
            
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel(level));
        }
    }

    public void RestartStars()
    {
        for (int i = 0; i < _levelList.Length; i++)
        {

            PlayerPrefs.SetString(_levelList[i].SceneName + "Stars", "0");
            Application.Quit();
        }
    }

    void LoadLevel(Level level)
    {
        GameLogic.Instance.SetCurrentLevel(level);
        SceneManager.LoadScene(level.SceneName);
    }
}
