using UnityEngine;
using System.Collections;
using BBGamelib;

//sample for handling events of NSNotification
public class HelloNSNotification : CCLayer
{
	public static CCScene  Scene()
	{
		CCScene scene = new CCScene();
		HelloNSNotification layer = new HelloNSNotification();
		scene.addChild(layer);
		return scene;
	}
	public HelloNSNotification(){
		HelloNSNotificationReceiver receiver = new HelloNSNotificationReceiver ();
		addChild (receiver);

		HelloNSNotificationSender sender = new HelloNSNotificationSender ();
		addChild (sender);
	}
}

//receiver
public class HelloNSNotificationReceiver : CCNode{
	public override void onEnter ()
	{
		base.onEnter ();
		
		//regist event listener to NSNotificationCenter
		NSNotificationCenter.defaultCenter.addObserver (this, onReceiveNotification, "HelloNSNotification");
	}
	
	public override void onExit ()
	{
		//remove event listener
		NSNotificationCenter.defaultCenter.removeObserver (this);
		base.onExit ();
	}
	
	void onReceiveNotification(NSNotification n){
		CCDebug.Log ("Hello I received event from:{0}", n.sender);
	}
}

//sender
public class HelloNSNotificationSender : CCNode{
	public HelloNSNotificationSender(){
		//create a button to trigger event
		Vector2 size = CCDirector.sharedDirector.winSize;
		CCMenuItemFont.FontSize = 28;
		CCMenuItem button1 = new CCMenuItemFont("Cocos2d", onButtonTouched);
		button1.userTag = "Cocos2d";

		CCMenuItem button2 = new CCMenuItemFont("Unity", onButtonTouched);
		button2.userTag = "Unity";

		CCMenu menu = new CCMenu(button1, button2);
		menu.alignItemsHorizontallyWithPadding(20);
		menu.position = new Vector2(size.x/2, size.y/2 - 50);
		addChild(menu);
	}
	
	void onButtonTouched(object button){
		NSNotificationCenter.defaultCenter.postNotification ("HelloNSNotification", button);
	}
}