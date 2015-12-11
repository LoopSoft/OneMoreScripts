using UnityEngine;

public class ControlButtons : MonoBehaviour {

    bool watch_video = true;
    public void ChangeOfScene(string scene)
    { Application.LoadLevel(scene); }

    public void QuitGame()
    { Application.Quit(); }

    public void ActivatePopUp(GameObject pop_up)
    { pop_up.SetActive(true); }

    public void Redirection (string link)
    { Application.OpenURL(link); }

    public void WatchVideo()
    {
        if (watch_video)
        {
            Stopwatch.over_time = false;
            Stopwatch.second = 10;
        }
    }
    void Update()
    {
        if (Application.loadedLevelName == "MenuScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
                print("1");
            }
        }
    }
}
