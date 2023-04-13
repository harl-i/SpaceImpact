using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public int _scene;

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
        SceneManager.LoadScene(_scene);
    }
}
