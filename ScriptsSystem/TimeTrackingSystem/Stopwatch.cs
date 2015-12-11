using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stopwatch : MonoBehaviour {

    public Text second_text;
    public static float second = 60;
    public GameObject end_game;

    public static bool over_time = false;

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel("MenuScene");
    }

    void Start()
    {
        second = 60;
        over_time = false;
    }
    void Update () {
        if (!over_time) {
            if (second > 0)
                second -= Time.deltaTime;
            else
            {
                over_time = true;
                end_game.SetActive(true);
                StartCoroutine(RestartGame());
            }
        }
        int aux = (int)second;
        second_text.text = aux.ToString();
	}
}
