using UnityEngine;
using System.Collections;
using BBGamelib;

public class HelloFlash : CCLayer
{
	public static CCScene  Scene()
	{
		CCScene scene = new CCScene();
		HelloFlash layer = new HelloFlash();
		scene.addChild(layer);
        return scene;
    }
    public HelloFlash()
	{
		CCSpriteFrameCache.sharedSpriteFrameCache.addSpriteFramesWithFile ("cocos2d-unity-demo/Flashs/demo");

		//load flash file
		BBFlash flash = BBFlashFactory.LoadFlash ("cocos2d-unity-demo/Flashs/demo-swf.bytes");

		//check the flash version
		CCDebug.Log ("Flash version:{0}", flash.flashVersion);

		//check the frame rate
		CCDebug.Log ("Frame rate:{0}", flash.frameRate);

		//create movie clip from flash
		BBFlashMovie demo = flash.ctMovie ("wizard");

		//set loop mode
		demo.loop = true;

		//change fps
		demo.fps = 60;

		//play whole movie
//		demo.play ();

		//play movie with specify frame
//		demo.gotoAndPlay (0, 90);

		//play movie with specify label
//		demo.gotoAndPlay ("wait_start", "wait_end");

		//get the bounds of movie clip
//		CCDebug.Log ("Bounds is {0}", demo.bounds);

		//set the tween mode. The default mode is SkipNoLabelFrames which will skip frames withtout label if needed. 
//		demo.tweenMode = kTweenMode.SkipNoLabelFrames;
		
		//set the frame event mode. Let's talk later.
//		demo.frameEventMode = kFrameEventMode.LabelFrame;

		//play movie with a callback
		demo.play (onMovieClipEnded);

		//only frames which has label will pop up a event.
		demo.frameEventMode = kFrameEventMode.LabelFrame;

		//all frames will pop up a event.
		demo.frameEventMode = kFrameEventMode.EveryFrame;


		//regist frame event listener. Tip: all children of movie will pop up its event.
		demo.frameListener = delegate(BBFlashMovie obj) {
			if(obj == demo && obj.curLabel == "mov_start"){
				CCDebug.Log ("The movie is start to mov.");
			}
		};

		demo.position = CCDirector.sharedDirector.winSize * 0.5f;
		addChild (demo);
	}

	void onMovieClipEnded(BBFlashMovie mc){
		CCDebug.Log ("The movie is finished now.");
	}

}

