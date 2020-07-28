using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureADD_Script : MonoBehaviour
{
    public Button[] btns_Textures;
    public Texture[] Textures_;
    [SerializeField] Renderer[] CHair_parts;

    public void Btn_1()
    {
        foreach (var chair in CHair_parts)
        {

            chair.sharedMaterial.mainTexture = Textures_[0];
            //print("YELLOW");
        }
    }
    public void Btn_2()
    {
        foreach (var chair in CHair_parts)
        {

            chair.sharedMaterial.mainTexture = Textures_[1];
           //print("GREEN");
        }
    }

    public void Btn_3()
    {
        foreach (var chair in CHair_parts)
        {
            chair.sharedMaterial.mainTexture = Textures_[2];
            //print("GREEN");
        }
    }
    public void Btn_4()
    {
        foreach (var chair in CHair_parts)
        {    
           chair.sharedMaterial.mainTexture = Textures_[3];
                  
        }
    }

    public void Btn_5()
    {
        foreach (var chair in CHair_parts)
        {
           chair.sharedMaterial.mainTexture = Textures_[4];
           //print("GREEN");
        }
    }
}
