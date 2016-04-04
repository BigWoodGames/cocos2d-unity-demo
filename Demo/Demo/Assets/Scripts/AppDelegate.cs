using UnityEngine;
using System.Collections;
using BBGamelib;

public class AppDelegate : CCAppDelegate {
	public const string EVENT_APP_EXIT = "EVENT_APP_EXIT";
	public override void applicationRunOnceOnBuilding ()
	{
		base.applicationRunOnceOnBuilding ();
		
		//add components need to pool
		_factory.generateNodeGearsInEditMode(1024);
		_factory.generateSpriteGearsInEditMode(1024);
		_factory.generateLabelGearsInEditMode(16);
	}
	
	public override void applicationDidFinishLaunching ()
	{
		_window.setResolutionHeight (640);
		_view.setFrame (_window.bounds);
		CCDirector.Reset ();
		_director = CCDirector.sharedDirector;
		_director.displayError = true;
		_director.displayStats = true;
		_director.displayLink = this;
		_director.animationInterval = 1.0f / 60;
		_director.view = _view;
		_window.rootViewController = _director;

		_director.presentScene(HelloWorldLayer.Scene ());
//		_director.presentScene(HelloEvents.Scene ());
//		_director.presentScene(HelloMouseEvent.Scene ());
//		_director.presentScene(HelloKeyboardEvent.Scene ());
//		_director.presentScene(HelloNSNotification.Scene ());
//		_director.presentScene(HelloFlash.Scene ());

	}
	
	void OnApplicationQuit() {
	}
	void OnApplicationPause(bool paused)
	{
	}
}