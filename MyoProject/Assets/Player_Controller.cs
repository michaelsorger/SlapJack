using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour { 

    private Rigidbody rb;
    public float horizontalSpeed;
    public float verticalSpeed;
    public JointOrientation mouse;
    private Vector3 vect;

    Animator anim;
    CapsuleCollider col_size;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        horizontalSpeed = mouse.horizontalSpeed;
        verticalSpeed = mouse.verticalSpeed;
        vect = new Vector3(0, 0, 0);
	}

    // Update is called once per frame
    void Update() {
        rb.velocity = vect;
    }
       
    void OnCollisionEnter(Collision theCollision)
    {
       if(theCollision.gameObject.name == "Joint")
        {
            theCollision.gameObject.GetComponent<Rigidbody>().AddForce(horizontalSpeed * 100, 0, verticalSpeed);
            vect.y = verticalSpeed;
            vect.x = (horizontalSpeed * 100);
            Debug.Log("hit the bat");
        }
    }
}
