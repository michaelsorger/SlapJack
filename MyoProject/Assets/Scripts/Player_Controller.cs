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
    long timer;

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
        if(!isHit)
        this.gameObject.GetComponent<Rigidbody>().AddForce(-500f, 0, -500f);
        //if (mouse.thalmicMyo.pose == Pose.FingersSpread)
        //{
        //}
        if (isHit)
        {
            vect.y = vect.y - (relativeTime / 1000);
            vect.x = (vect.x > 0) ? vect.x - (relativeTime / 10000) : 0;
            vect.z = (vect.z > 0) ? vect.z - (relativeTime / 10000) : 0;
            relativeTime++;

            
            //Vector3 dood = gameObject.transform.position;
            //if ((DateTime.Now.Ticks - timer) > 300000 && (dood.y < 3))
            //{
            // //  / this.gameObject.GetComponent<Rigidbody>().AddForce(.5f, .5f, .5f);
            //    //Vector3 identity = new Vector3(0f, 0f, 0f);
            //    //gameObject.GetComponent<Rigidbody>().velocity = identity;
            //    isHit = false;
            //    //rb.velocity = identity;
            //    Destroy(gameObject, 10.0f);
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
            timer = DateTime.Now.Ticks;

            GameObject clone = gameObject;
            Destroy(gameObject, 10f);
            
            Instantiate(clone, new Vector3(160, 0, 161), clone.transform.rotation);
        }
    }


    public float getXVal()
    {
        return gameObject.transform.position.x;
    }

    public float getZVal()
    {
        return gameObject.transform.position.z;
    }

}
