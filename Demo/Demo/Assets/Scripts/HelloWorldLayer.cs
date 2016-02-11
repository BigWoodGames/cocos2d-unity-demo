using UnityEngine;
using System.Collections;
using BBGamelib;

public class HelloWorldLayer : CCLayer {
	// Helper class method that creates a Scene with the HelloWorldLayer as the only child.
	public static CCScene  Scene()
	{
		// 'scene' is an autorelease object.
		CCScene scene = new CCScene();
		
		// 'layer' is an autorelease object.
		HelloWorldLayer layer = new HelloWorldLayer();
		
		// add layer as a child to scene
		scene.addChild(layer);
		
		// return the scene
		return scene;
	}
	// on "init" you need to initialize your instance
	protected override void init ()
	{
		base.init ();

		// create and initialize a Label
		CCLabelTTF label = new CCLabelTTF("Hello World","Arial", 64);
		
		// ask director for the window size 
		Vector2 size = CCDirector.sharedDirector.winSize;
		
		// position the label on the center of the screen
		label.position = size / 2;
		
		// add the label as a child to this Layer
		addChild(label);

		
		//
		// menu items
		//
		
		// Default font size will be 28 points.
		CCMenuItemFont.FontSize = 28;
		
		// Cocos2d Menu Item using blocks
		CCMenuItem itemCocos2d = new CCMenuItemFont("Cocos2d", delegate(object sender) {
			label.text = "Hello Cocos2d";                               
		});
		
		// Unity Menu Item using blocks
		CCMenuItem itemUnity = new CCMenuItemFont("Unity", delegate(object sender) {
			label.text = "Hello Unity";                               
		});
		
		
		CCMenu menu = new CCMenu(itemCocos2d, itemUnity);

		menu.alignItemsHorizontallyWithPadding(20);
		menu.position = new Vector2(size.x/2, size.y/2 - 50);
		
		// Add the menu to the layer
		addChild(menu);
	}
}
