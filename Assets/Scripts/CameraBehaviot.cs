using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviot : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.5f, -2.9f); //distance from player capsule; public --> u can change it in Unity

    private Transform target; //transform data about smth(player)

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform; //get transform data about player
    }

    private void LateUpdate() //this method starts after default Update method --> u get actually transform information
    {
        this.transform.position = target.TransformPoint(camOffset); //position of camera(MainCamera.tranform.position) is relative to the player

        this.transform.LookAt(target); //automatically rotate cameta to player; "camera is looks at target(player position)"
    }
}
