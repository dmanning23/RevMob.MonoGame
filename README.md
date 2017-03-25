RevMobBuddy
=========

MonoGame library for menus and game state management.

This library currently is available for MonoGame.iOS & MonoGame.Android

Extra instructions for use on Android:
--------------------------------------

add line to manifest.xml: 
```
<activity android:name="com.revmob.FullscreenActivity" android:theme="@android:style/Theme.Translucent" android:configChanges="keyboardHidden|orientation"></activity>
```

in Activity, put game inside a FrameLayout:
```
_mainLayout = new FrameLayout(this);
_mainLayout.AddView(gameView);
SetContentView(_mainLayout);
```

add IAdManager service in Activity.OnCreate
```
g.Services.AddService<IAdManager>(new AndroidRevMobManager(g, _mainLayout));
```

call IAdManager.Initialze in Game.Initialize
```
var ads = Services.GetService<IAdManager>();
ads.Initialize();
```

To use RevMobBuddy in your project, install the Nuget package: 

https://www.nuget.org/packages/RevMobBuddy/

For several examples of how to use RevMobBuddy, a complete game with screens and all the various ads can be used as a recipe:

https://github.com/dmanning23/RevMobBuddySample
