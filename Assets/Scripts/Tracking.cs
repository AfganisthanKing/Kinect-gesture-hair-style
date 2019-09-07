using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using Microsoft.Kinect.Face;

public class Tracking : MonoBehaviour
{
    public GameObject BodysourceManger;
    private BodySourceManager Bodymanager;

    public Windows.Kinect.JointType TrackJoint;
    //public Windows.Kinect.JointType Handswipe;
    public Body[] Bodies;
    public float speed = 10f;

    //public GameObject RightHandTracker;
    //public Color[] colors;


  
    // Start is called before the first frame update
    void Start()
    {
        if (BodysourceManger == null)
        {
            Debug.Log("Assign body source manager");
        }
        else
        {
            Bodymanager = BodysourceManger.GetComponent<BodySourceManager>();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bodymanager == null)
        {
            return;
        }
        Bodies = Bodymanager.GetData();
        if (Bodies == null)
        {
            return;
        }
        foreach (var b in Bodies)
        {
           // Debug.Log(b.IsTracked);
            if (b == null)
            {
                continue;
            }
            if (b.IsTracked)
            {
                var _pos = b.Joints[TrackJoint].Position;
                this.gameObject.transform.position = new Vector3(_pos.X * speed, _pos.Y * speed);
                //var _handswipe = b.Joints[Handswipe].Position;
                //RightHandTracker.transform.position = new Vector3(_handswipe.X * speed, _handswipe.Y * speed);
            }
            
        }
        //if (RightHandTracker.transform.position.x < -1)
        //{
        //    Debug.Log("We can swipe");
        //   int _rand = Random.Range(0, colors.Length);
        //    this.gameObject.GetComponent<Renderer>().material.color = colors[_rand];
        //    return;
        //}
        // get bodies either from BodySourceManager object get them from a BodyReader
        //var bodySourceManager = bodyManager.GetComponent<BodySourceManager>();
        //bodies = bodySourceManager.GetData();
        // get bodies either from BodySourceManager object get them from a BodyReader
        //var bodySourceManager = bodyManager.GetComponent<BodySourceManager>();
        //bodies = bodySourceManager.GetData();
    }
}

