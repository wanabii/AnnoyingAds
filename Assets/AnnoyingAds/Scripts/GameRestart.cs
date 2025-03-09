using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    // Метод, вызываемый для рестарта игры
    public void RestartGame()
    {
        // Перезагружает текущую активную сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

