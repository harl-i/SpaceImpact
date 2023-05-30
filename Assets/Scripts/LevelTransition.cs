using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int _firstLevel = 1;
    private int _startScreen = 0;
    private int _gameOverScreen = 10;

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

    public void StartNewGame()
    {
        StartCoroutine(LoadFirstLevel());
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadStartSceen());
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
        PlayerPrefs.SetString(PlayerParameters.ActiveSuperWeapon, PlayerParameters.RocketGun);
    }

    private void ChangeScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentScene);
    }
}
