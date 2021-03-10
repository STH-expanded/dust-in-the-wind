using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Image playerColorHUD;
    private Color playerColor;

    // Use this for initialization
    void Start()
    {
        playerColor = player.transform.Find("Blow_Chara_Mesh").transform.Find("Blow_Chara_Mesh_Body").GetComponent<Renderer>().material.GetColor("Color_DFC0C2F9");
        playerColorHUD.GetComponent<Image>().color = getColorFromRGBA(playerColor.ToString());


    }

    private Color getColorFromRGBA(string rgba)
    {
        int start = rgba.IndexOf("(");
        int length = rgba.IndexOf(")") - start - 2;
        string s = rgba.Substring(start + 1, length);

        string[] nums = s.Split(","[0]);

        float _red, _green, _blue, _a;

        float.TryParse(nums[0], out _red);
        float.TryParse(nums[1], out _green);
        float.TryParse(nums[2], out _blue);
        float.TryParse(nums[3], out _a);

        Debug.Log(_red + "," + _green + "," + _blue + "," + _a);

        Color sourceColor = new Color(_red, _green, _blue, 255);
        Color32 convertedColor;
        convertedColor = sourceColor;

        return convertedColor;
    }
}
