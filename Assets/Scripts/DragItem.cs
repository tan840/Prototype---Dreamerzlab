using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    Vector3 M_offset;
    float gameobjectOffset;
    public LayerMask layerMask;

    GameManager gmanager;

    public Material highlightMat;
    public Material defMat;

    Renderer otherRenderer;
    bool turnMeshOn;



    void OnMouseDown()
    {
        gameobjectOffset = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        M_offset = gameObject.transform.position - GetMouseWorldPOS();
        //print("click");



    }

    private Vector3 GetMouseWorldPOS()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = gameobjectOffset;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPOS() + M_offset;
        //print("Drag");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, layerMask))
        {
            print("ray ray");
            var item = hit.transform;
            if (item.tag == this.gameObject.tag)
            {
                if (GameManager.pos_rotation == 1 && item.tag == "Chair_back")
                {
                    //print("hit");
                    //MeshRenderer renderer = item.GetComponent<MeshRenderer>();
                    //renderer.enabled = true;
                    //this.gameObject.SetActive(false);
                    otherRenderer = item.GetComponent<MeshRenderer>();
                    this.gameObject.GetComponent<Renderer>().material = highlightMat;
                    turnMeshOn = true;
                }

                else if (GameManager.pos_rotation == 3 && item.tag == "Chair_seat")
                {
                    //print("hit");
                    //MeshRenderer renderer = item.GetComponent<MeshRenderer>();
                    //renderer.enabled = true;
                    otherRenderer = item.GetComponent<MeshRenderer>();
                    this.gameObject.GetComponent<Renderer>().material = highlightMat;
                    turnMeshOn = true;

                    //this.gameObject.SetActive(false);
                }
                else if (GameManager.pos_rotation == 4 && item.tag == "Chair_leg")
                {
                    //print("hit");
                    //MeshRenderer renderer = item.GetComponent<MeshRenderer>();
                    //renderer.enabled = true;

                    //this.gameObject.SetActive(false);
                    otherRenderer = item.GetComponent<MeshRenderer>();
                    this.gameObject.GetComponent<Renderer>().material = highlightMat;
                    turnMeshOn = true;
                }




            }

        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = defMat;
            turnMeshOn = false;
        }
    }

    void OnMouseUp()
    {
        if (turnMeshOn)
        {
            otherRenderer.enabled = true;
            this.gameObject.SetActive(false);
        }
    }



}
