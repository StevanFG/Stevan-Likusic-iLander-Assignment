using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    public float movespeed;

    // Everything with this script moves to the left of the screen making it seem like player moves right

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * movespeed) * Time.deltaTime;
    }
}
