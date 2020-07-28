using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;


    public Transform Plane;

    float roaterAngle = 1;

    public Transform[] SpawnPoint;
    public GameObject Chair_leg;
    public GameObject back_rest;
    public GameObject seat;
    //buttons as gameobject so I can deactivate
    public GameObject[] Btns;

    public AudioSource waa;


    //fixed number of rotation determined by the value
    public static int pos_rotation = 0;

    //menu buttons
    public Button[] menuBtns;
    //menu pannel
    public GameObject menu_Panel;




    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            Quaternion rotation = Quaternion.Euler(0, -currentSwipe.x * 0.1f, 0);
            //normalize the 2d vector
            currentSwipe.Normalize();
            
            

            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                //Debug.Log("left swipe");

                roaterAngle++;
                //print(roaterAngle);
                //Quaternion toRotation = Plane.transform.rotation * rotation;
                //Plane.transform.rotation *= Plane.transform.rotation * rotation;
                //Plane.transform.rotation = Quaternion.Lerp(Plane.transform.rotation, toRotation, 5f);


            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
               // Debug.Log("right swipe");
                roaterAngle--;
                if (roaterAngle < 1)
                {
                    roaterAngle = 4;
                }
                //print(roaterAngle);
            }
        }

        switch (roaterAngle)
        {

            case 2:
                //Plane.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                Plane.transform.rotation = Quaternion.Lerp(Plane.transform.rotation, Quaternion.Euler(0f, 90f, 0f), 3f *Time.deltaTime);
                pos_rotation = 1;
                break;
            case 3:
                //Plane.transform.rotation = Quaternion.Euler(0f, 120f, 0f);
                Plane.transform.rotation = Quaternion.Lerp(Plane.transform.rotation, Quaternion.Euler(0f, 180f, 0f), 3f * Time.deltaTime);
                pos_rotation = 2;
                break;
            case 4:
                //Plane.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                Plane.transform.rotation = Quaternion.Slerp(Plane.transform.rotation, Quaternion.Euler(0f, 270f, 0f), 3f * Time.deltaTime);
                pos_rotation = 3;

                break;
            case 5:
                roaterAngle = 1;
                break;

            default:
                //Plane.transform.rotation = Quaternion.Euler(0f, 30f, 0f);
                Plane.transform.rotation = Quaternion.Slerp(Plane.transform.rotation, Quaternion.Euler(0f, 30f, 0f), 3f * Time.deltaTime);
                pos_rotation = 4;

                break;
        }


    } 

    public void Btn_BackRest()
    {
        Instantiate(back_rest, SpawnPoint[2].transform.position, Quaternion.identity);
        //print("hoise");
        Btns[1].SetActive(false);
        waa.Play();
        
    }
    public void Btn_Chair_seat()
    {
        Instantiate(seat, SpawnPoint[1].transform.position,  Quaternion.Euler(-90, 0, 0));
        //print("hoise");
        Btns[2].SetActive(false);
        waa.Play();

    }
    public void Btn_Leg()
    {
        Instantiate(Chair_leg, SpawnPoint[0].transform.position, Quaternion.Euler(-90, 0, 0));
        //print("hoise");
        Btns[0].SetActive(false);
        waa.Play();

    }

    public void Level1()
    {
        menu_Panel.SetActive(false);

    }
    public void menu_level1()
    {
        SceneManager.LoadScene("Level1");

    }
    public void level2()
    {
        SceneManager.LoadScene("Level2");

    }
    public void Quit()
    {
        Application.Quit();

    }
    public void MenuBtn()
    {
        menu_Panel.SetActive(true);

    }


}
