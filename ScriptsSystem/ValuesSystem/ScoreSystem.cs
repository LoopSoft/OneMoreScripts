using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public bool high_scores = false;
    public Text total_of_points;
    public Text best_score;
    public Text one_more;
    public Text one_less;
    public Text zero;

    void ScoresStores()
    {
        if (PossibleValues.total_of_points > PlayerPrefs.GetInt("Points"))
        {
            PlayerPrefs.SetInt("Points", PossibleValues.total_of_points);
            PlayerPrefs.SetInt("+1", PossibleValues.one_more);
            PlayerPrefs.SetInt("0", PossibleValues.zero);
            PlayerPrefs.SetInt("-1", PossibleValues.one_less);
        }   
    }
    void SetScore()
    {
        if (!high_scores) {
            if (total_of_points != null)
                total_of_points.text = PossibleValues.total_of_points.ToString();
            if (best_score != null)
                best_score.text = PlayerPrefs.GetInt("Points").ToString();
            if (one_more != null)
                one_more.text = PossibleValues.one_more.ToString();
            if (one_less != null)
                one_less.text = PossibleValues.one_less.ToString();
            if (zero != null)
                zero.text = PossibleValues.zero.ToString();
        }
        else
        {
            if(best_score != null)
                best_score.text = PlayerPrefs.GetInt("Points").ToString();
            if (one_more != null)
                one_more.text = PlayerPrefs.GetInt("+1").ToString();
            if (one_less != null)
                one_less.text = PlayerPrefs.GetInt("-1").ToString();
            if (zero != null)
                zero.text = PlayerPrefs.GetInt("0").ToString();
        }
    }
	void Update () {
        SetScore();
        ScoresStores();
    }
}
