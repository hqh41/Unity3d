using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Leap;

public class CubeInteraction : MonoBehaviour {
	Controller controller;
	public Color c;
	public static Color selectedColor;
	public bool selectable = false; 

	public GameObject myCubeVertical;
	public GameObject myCubeHorizontal;

	public bool spinLeft;
	public bool spinRight;
	public bool spinUp;
	public bool spinDown;
	// Use this for initialization
	void Start () {
		controller = new Controller();	
		controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
		controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
		controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);
		controller.Config.Save();		
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		GestureList gestures = frame.Gestures();
		Hand hand = frame.Hands.Frontmost;
		if(hand.IsRight)
		{
			for(int i = 0; i<gestures.Count; i++)
			{
				Gesture gesture = gestures[i];
				if(gesture.Type == Gesture.GestureType.TYPESWIPE)
				{
					SwipeGesture Swip = new SwipeGesture(gesture);
					Vector swipDirection = Swip.Direction;
					if(swipDirection.x < 0 &&Math.Abs(swipDirection.x) >Math.Abs(swipDirection.y))
					{
						Debug.Log("Left");
						spinLeft =  true;
						spinRight = false;

					}
					if(swipDirection.x > 0 && Math.Abs(swipDirection.x) >Math.Abs(swipDirection.y))
					{
						Debug.Log("Right");
						spinRight =  true;
						spinLeft = false;

					}
					if(swipDirection.y < 0 &&  Math.Abs(swipDirection.x) <=Math.Abs(swipDirection.y))
					{
						Debug.Log("Down");
					
						spinUp = false;
						spinDown = true;
					}
					if(swipDirection.y > 0 && Math.Abs(swipDirection.x) <=Math.Abs(swipDirection.y))
					{
						Debug.Log("Up");

						spinUp = true;
						spinDown = false;
					}
				}
			}
		}
		if (spinLeft == true)
		{
			myCubeHorizontal.transform.Rotate(Vector3.up, 45* Time.deltaTime);
		}
		if (spinRight == true)
		{
			myCubeHorizontal.transform.Rotate(Vector3.down, 45* Time.deltaTime);
		}
		if (spinUp == true)
		{
			myCubeVertical.transform.Rotate(Vector3.right, 45* Time.deltaTime);
		}
		if (spinDown == true)
		{
			myCubeVertical.transform.Rotate(Vector3.left, 45* Time.deltaTime);
		}
	}


	/*void OnTriggerEnter(Collider c)
	{
		Debug.Log('1');
		if(c.gameObject.transform.parent.name.Equals("index"))
		{
			Debug.Log('2');
			if(this.selectable)
			{
				CubeInteraction.selectedColor = this.c;
				this.transform.Rotate(Vector3.up, 33);
				return;
			}
			transform.gameObject.GetComponent<Renderer>().material.color = CubeInteraction.selectedColor;
		}
	}*/
}
