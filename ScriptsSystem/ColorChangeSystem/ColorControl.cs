using UnityEngine;
using UnityEngine.UI;

public sealed class ColorControl : MonoBehaviour {
    
    //
    private static ColorControl color_setting = new ColorControl();
    public static ColorControl Instance { get { return color_setting; } }
    //
    //
    static float _R = 0;
    static float _G = 0;
    static float _B = 0;
    static float _A = 0;
    public float R
    {
        get { return _R; }
        set { _R = value; }
    }
    public float G
    {
        get { return _G; }
        set { _G = value; }
    }
    public float B
    {
        get { return _B; }
        set { _B = value; }
    }

    public float A
    {
        get { return _A; }
        set { _A = value; }
    }
}
