using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private SaveLoadSystem _saveLoadSystem;
    private int _firstLevel = 1;
    private int _startScreen = 0;
    private int _gameOverScreen = 10;
    private int _continuumScreen = 11;

    [DllImport("__Internal")]
    private static extern void ShowFullscreenAdv();

    private void Awake()
    {
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");
    }

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
        PlayerData playerData = _saveLoadSystem.Load();

        if (playerData != null)
        {
            playerData.Health = 3;

            ReduceContinuum(playerData);
        }
        _saveLoadSystem.Save(playerData);

        SceneManager.LoadScene(playerData.CurrentLevel);
    }

    private void ReduceContinuum(PlayerData playerData)
    {
        int continuumsCount = playerData.ContinuumsCount;
        playerData.ContinuumsCount = continuumsCount - 1;
    }

#if !UNITY_EDITOR
    public void EndShowAdvertisment()
    {
        Time.timeScale = 1.0f;
    }
#endif

    private IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(1f);

        SetStartPlayerData();

        SceneManager.LoadScene(_firstLevel);
    }

    private IEnumerator LoadStartSceen()
    {
#if !UNITY_EDITOR
        StartShowAdvertisment();
#endif

        yield return new WaitForSeconds(1f);

        //SetStartPlayerData();

        SceneManager.LoadScene(_startScreen);
    }

    private void SetStartPlayerData()
    {
        PlayerData playerData = new PlayerData
        {
            Health = 3,
            RocketsCount = 0,
            LasersCount = 0,
            LaserWallsCount = 0,
            Score = 0,
            ActiveSuperWeapon = PlayerParameters.RocketGun,
            ContinuumsCount = 3,
            CurrentLevel = 1
        };

        _saveLoadSystem.Save(playerData);
    }

    private void ChangeScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

#if !UNITY_EDITOR
        if ((currentScene + 1) % 2 == 0)
        {
            StartShowAdvertisment();
        }
#endif
        SaveSceneToPlayer(currentScene);
        SceneManager.LoadScene(++currentScene);
    }

    private void SaveSceneToPlayer(int currentScene)
    {
        PlayerData playerData = _saveLoadSystem.Load();

        if (playerData != null)
        {
            playerData.CurrentLevel = currentScene + 1;

            _saveLoadSystem.Save(playerData);
        }
    }

#if !UNITY_EDITOR
    private void StartShowAdvertisment()
    {
        Time.timeScale = 0;
        ShowFullscreenAdv();
    }
#endif
}