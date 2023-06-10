using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int _firstLevel = 1;
    private int _startScreen = 0;
    private int _gameOverScreen = 10;
    private int _continuumScreen = 11;
    private int _continuumCurrentCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SaveParameters saveParameters))
        {
            saveParameters.Save();

            ChangeScene();
        }
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene(_gameOverScreen);
    }
    
    public void LoadContinuumScreen()
    {
        SceneManager.LoadScene(_continuumScreen);
    }

    public void StartNewGame()
    {
        StartCoroutine(LoadFirstLevel());
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadStartSceen());
    }
    
    public void BackToGame()
    {
        ReduceContinuum();
        SceneManager.LoadScene(PlayerPrefs.GetInt(PlayerParameters.CurrentLevel));
    }

    private void ReduceContinuum()
    {
        _continuumCurrentCount = PlayerPrefs.GetInt(PlayerParameters.Continuum);
        PlayerPrefs.SetInt(PlayerParameters.Continuum, --_continuumCurrentCount);
    }

    private IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(1f);

        SetStartPlayerPrefs();

        SceneManager.LoadScene(_firstLevel);
    }

    private IEnumerator LoadStartSceen()
    {
        yield return new WaitForSeconds(1f);

        SetStartPlayerPrefs();

        SceneManager.LoadScene(_startScreen);
    }

    private void SetStartPlayerPrefs()
    {
        PlayerPrefs.SetInt(PlayerParameters.Health, 3);
        PlayerPrefs.SetInt(PlayerParameters.RocketsCount, 0);
        PlayerPrefs.SetInt(PlayerParameters.LasersCount, 0);
        PlayerPrefs.SetInt(PlayerParameters.LaserWallsCount, 0);
        PlayerPrefs.SetInt(PlayerParameters.Score, 0);
        PlayerPrefs.SetInt(PlayerParameters.Continuum, 3);
        PlayerPrefs.SetInt(PlayerParameters.CurrentLevel, 1);
        PlayerPrefs.SetString(PlayerParameters.ActiveSuperWeapon, PlayerParameters.RocketGun);

    }

    private void ChangeScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentScene);
    }
}
