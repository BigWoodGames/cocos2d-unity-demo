using UnityEngine;
using System.Collections;
using BBGamelib;

//sample for handling events of CCLayer
public class HelloKeyboardEvent : CCLayer
{
	public static CCScene  Scene()
	{
		CCScene scene = new CCScene();
		HelloKeyboardEvent layer = new HelloKeyboardEvent();
		scene.addChild(layer);
		return scene;
	}
	
	public HelloKeyboardEvent(){
		//only pc/mac/web version has mouse events
		#if UNITY_STANDALONE || UNITY_WEBGL
		this.isKeyboardEnabled = true;
		this.keyboardPriority = 10;
		#endif
	}
	
	#if UNITY_STANDALONE || UNITY_WEBGL
	
	public override bool ccKeyDown (NSEvent theEvent)
	{
		CCDebug.Log ("ccKeyDown={0}", theEvent.keyCode);
		return true;
	}

	public override bool ccKeyUp (NSEvent theEvent)
	{
		CCDebug.Log ("ccKeyUp={0}", theEvent.keyCode);
		return true;
	}

	#endif
}