using UnityEngine;
using System.Collections;
using BBGamelib;

//sample for handling events of CCLayer
public class HelloMouseEvent : CCLayer
{
	public static CCScene  Scene()
	{
		CCScene scene = new CCScene();
		HelloMouseEvent layer = new HelloMouseEvent();
		scene.addChild(layer);
		return scene;
	}
	
	public HelloMouseEvent(){
		//only pc/mac/web version has mouse events
		#if UNITY_STANDALONE || UNITY_WEBGL
		this.isMouseEnabled = true;
		this.mousePriority = 10;
		#endif
	}

	#if UNITY_STANDALONE || UNITY_WEBGL
	
	public override bool ccMouseDown (NSEvent theEvent)
	{
		Vector2 touchPoint = convertMouseEventToNodeSpace (theEvent);
		CCDebug.Log ("ccMouseDown:{0}", touchPoint);
		return true;
	}

	public override bool ccMouseUp (NSEvent theEvent)
	{
		return true;
	}

	public override bool ccMouseEntered (NSEvent theEvent)
	{
		return true;
	}

	public override bool ccMouseExited (NSEvent theEvent)
	{
		return true;
	}

	public override bool ccMouseMoved (NSEvent theEvent)
	{
		return true;
	}

	public override bool ccMouseDragged (NSEvent theEvent)
	{
		return true;
	}

	#endif
}
