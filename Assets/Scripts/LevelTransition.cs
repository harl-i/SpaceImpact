using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int _firstLevel = 1;

    public void StartNewGame()
    {
        StartCoroutine(LoadFirstLevel());
    }

    private IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(1f);

        SetStartPlayerPrefs();

        SceneManager.LoadScene(_firstLevel);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SaveParameters saveParameters))
        {
            saveParameters.Save();

            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentScene);
    }
}
