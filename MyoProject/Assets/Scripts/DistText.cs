using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistText : MonoBehaviour
{
    public Player_Controller player;
    public JointOrientation joint;
    Text txt;
    private int currentscore = 0;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        currentscore = 0;
        txt.text = "Score : " + currentscore;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("current score = " + currentscore);
        currentscore = (int) System.Math.Sqrt(((player.getXVal() - joint.getXVal()) * (player.getXVal() - joint.getXVal())) - (player.getZVal() - joint.getZVal()) * (player.getZVal() - joint.getZVal()));
        txt.text = "Distance = " + currentscore;
       // Debug.Log("current score = " + currentscore);
    }
}