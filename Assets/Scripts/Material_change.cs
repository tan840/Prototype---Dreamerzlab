using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_change : MonoBehaviour
{
    public Button[] btns_colours;
    public Material[] colour_mat;
    [SerializeField] Renderer[] CHair_parts;



    public void Btn_1()
    {
        foreach (var chair in CHair_parts)
        {
            //CHair_parts[0] = CHair_parts[0].GetComponent<Renderer>();
            //chair.enabled = true;
           chair.sharedMaterial.color = colour_mat[0].color;
           print("YELLOW");
        }
    }
    public void Btn_2()
    {
        foreach (var chair in CHair_parts)
        {
            //chair = CHair_parts[1].GetComponent<Renderer>();
            //chair.enabled = true;
            chair.sharedMaterial.color = colour_mat[1].color;
           // print("GREEN");
        }
    }

    public void Btn_3()
    {
        foreach (var chair in CHair_parts)
        {
            //chair = CHair_parts[1].GetComponent<Renderer>();
            //chair.enabled = true;
            chair.sharedMaterial.color = colour_mat[2].color;
            //print("GREEN");
        }
    }
    public void Btn_4()
    {
        foreach (var chair in CHair_parts)
        {
            //chair = CHair_parts[1].GetComponent<Renderer>();
            //chair.enabled = true;
            chair.sharedMaterial.color = colour_mat[3].color;
            //print("GREEN");
        }
    }

    public void Btn_5()
    {
       foreach (var chair in CHair_parts)
       {
            //chair = CHair_parts[1].GetComponent<Renderer>();
            //chair.enabled = true;
           chair.sharedMaterial.color = colour_mat[4].color;
           //print("GREEN");
       }
    }
}
