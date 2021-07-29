using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField] private Text _moneu;
    [SerializeField] private GameObject _finishDisplay;
    [SerializeField] private GameObject _deathDisplay;
    public static Ui UiGlobal { private set; get; } 
    private int _scoreMoneu;

    private void Awake()
    {
        UiGlobal = this;
    }
    public void AddMoneu(int value)
    {
        _scoreMoneu += value;
        _moneu.text = _scoreMoneu.ToString();
    }
    public void Finish() => OnDisplay(_finishDisplay);
    public void Death() => OnDisplay(_deathDisplay);
    public void Restart()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    private void OnDisplay(GameObject display)
    {
        display.SetActive(true);
        Time.timeScale = 0.01f;
    }
}
