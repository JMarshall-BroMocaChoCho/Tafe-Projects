using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Rigidbody rigid;
    public float moveSpeed = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 tempPos = transform.position;

        float inputZ = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        tempPos.z = transform.position.z + inputZ;

        float inputX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        tempPos.x = transform.position.x + inputX;

        transform.position = tempPos;
    }
}
