using UnityEngine;
using System.Collections;
using BBGamelib;

//sample for handling events of CCLayer
public class HelloEvents : CCLayer
{
	public static CCScene  Scene()
	{
		CCScene scene = new CCScene();
		HelloEvents layer = new HelloEvents();
		scene.addChild(layer);
		return scene;
	}

	public HelloEvents(){
		this.isTouchEnabled = true;
		this.touchPriority = 10;

		//kCCTouchesMode.OneByOne mode is needed to recived single touch event
		this.touchMode = kCCTouchesMode.OneByOne;
	}

	public override bool ccTouchBegan (UITouch touch)
	{
		Vector2 touchPoint = convertTouchToNodeSpace (touch);
		CCDebug.Log ("Touch:{0}", touchPoint);
		return true;
	}

	public override void ccTouchMoved (UITouch touch)
	{
	}

	public override void ccTouchEnded (UITouch touch)
	{
	}

	public override void ccTouchCancelled (UITouch touch)
	{
	}
}


