using UnityEngine;
using System.Collections;
using BBGamelib;


public class Hello3D : CC3Layer
{	
	public static CCScene  Scene()
	{
		CCScene scene = new CCScene();
		Hello3D layer = new Hello3D();
		scene.addChild(layer);
		return scene;
	}

	public Hello3D()
	{
		CC3FbxGeneric hero = new CC3FbxGeneric("cocos2d-unity-demo/3D/Prefabs/Hero");
		hero.setUnityLayerRecursively ("3D");
		hero.position3D = new Vector3 (CCDirector.sharedDirector.winSize.x / 2, CCDirector.sharedDirector.winSize.y / 2 - 30, -700);
		hero.rotationY = 180;
		addChild (hero);

		hero.eventHandler = delegate (AnimationEvent evt){
			if(evt.stringParameter == "End"){
				hero.playAnimation("Idle");
			}
		};
	
		var delay = new CCDelayTime (3f);
		var attack = new CCCallBlock (delegate {
			hero.playAnimation("Punch");	
		});
		var seq = CCSequence.Actions (delay, attack);
		var repeat = new CCRepeatForever (seq as CCActionInterval);
		hero.runAction (repeat);
	}
}