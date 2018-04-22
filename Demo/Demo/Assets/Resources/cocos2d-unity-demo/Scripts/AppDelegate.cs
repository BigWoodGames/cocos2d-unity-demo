using UnityEngine;
using System.Collections;
using BBGamelib;

public class AppDelegate : CC3AppDelegate {
	public const string EVENT_APP_EXIT = "EVENT_APP_EXIT";
	public Camera camera3d;

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
		resetResolution(Screen.width, Screen.height, Screen.fullScreen);
		_view.setFrame (_window.bounds);
		CCDirector.Reset ();
		_director = CCDirector.sharedDirector;
		_director.displayError = true;
		_director.displayStats = true;
		_director.displayLink = this;
		_director.animationInterval = 1.0f / 60;
		_director.view = _view;
		_window.rootViewController = _director;
		camera3d.transform.position = Camera.main.transform.position;
//		_director.presentScene(HelloWorldLayer.Scene ());
//		_director.presentScene(HelloEvents.Scene ());
//		_director.presentScene(HelloMouseEvent.Scene ());
//		_director.presentScene(HelloKeyboardEvent.Scene ());
//		_director.presentScene(HelloNSNotification.Scene ());
//		_director.presentScene(HelloFlash.Scene ());
		_director.presentScene(Hello3D.Scene ());

	}
	public void resetResolution(int width, int height, bool isFullScreen)
	{
		CCDebug.Log("Appdelegate resetResolution: {0}x{1}", width, height);
		#if UNITY_STANDALONE || UNITY_WEBGL
		Screen.SetResolution (width, height, isFullScreen);
		#endif
		_window.setResolutionHeight (height);
		_view.setFrame (_window.bounds);
		if(_director != null)
			CCDirector.sharedDirector.resetWinSize();
	}
	
	void OnApplicationQuit() 
	{
		NSNotificationCenter.defaultCenter.postNotification (EVENT_APP_EXIT, this);
	}

	void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			NSNotificationCenter.defaultCenter.postNotification (EVENT_APP_EXIT, this);
		}
	}
}