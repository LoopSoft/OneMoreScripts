using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {

    public Image On;
    public Image Off;

    public Color color_on;
    public Color color_off;

	void Update()
    {
        if (On != null && Off != null && color_on != null && color_off != null) {
            if (MusicManager.flag_OnOffMusic)
            {
                On.color = color_on;
                Off.color = color_off;
            }
            else
            {
                On.color = color_off;
                Off.color = color_on;
            }
        }
    }
}
