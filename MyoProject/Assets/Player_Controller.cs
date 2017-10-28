using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = Thalmic.Myo.Pose;


public class Player_Controller : MonoBehaviour
{

    public Rigidbody rb;
    public float horizontalSpeed;
    public float verticalSpeed;
    public JointOrientation mouse;
    private Vector3 vect;
    float relativeTime;
   public  bool isHit;

    Animator anim;
    CapsuleCollider col_size;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        horizontalSpeed = mouse.horizontalSpeed;
        verticalSpeed = mouse.verticalSpeed;
        vect = new Vector3(0, 0, 0);
        relativeTime = 0;
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
            this.gameObject.GetComponent<Rigidbody>().AddForce(-500f, 0, -500f);
        //if (mouse.thalmicMyo.pose == Pose.FingersSpread)
        //{
        //}
        if (isHit)
        {
            vect.y = vect.y - (relativeTime / 1000);
            relativeTime++;

            Vector3 dood = gameObject.transform.position;
            //if (vect.y < 3)
            //{
            //    vect.x = vect.x;
            //    vect.z = vect.z;
            //    isHit = false;
            //}
        }
        rb.velocity = vect;
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Joint")
        {
            isHit = true;
            //theCollision.gameObject.GetComponent<Rigidbody>().AddForce(horizontalSpeed * 10, 0, verticalSpeed);
            //vect.y = verticalSpeed * 5;
            //vect.x = (horizontalSpeed * 10);
            //vect.z = verticalSpeed * 5;

            vect.y = Math.Abs(mouse.thalmicMyo.gyroscope.y / 10);
            vect.x = Math.Abs(mouse.thalmicMyo.gyroscope.x / 10);
            vect.z = Math.Abs(mouse.thalmicMyo.gyroscope.z / 10);
            theCollision.gameObject.GetComponent<Rigidbody>().AddForce(vect.x, 0, vect.z);
            Debug.Log("hit the bat");
        }
    }
}
