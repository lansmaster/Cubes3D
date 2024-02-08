using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    private bool _enabled = false;

    private void Start()
    {
        SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetActive(!_enabled);
        }
    }

    private void SetActive(bool active)
    {
        _window.SetActive(active);
        Time.timeScale = active ? 0f : 1f;

        _enabled = active;
    }

    public void ApplicationExit() // на кнопку
    {
        Application.Quit();
    }
}
