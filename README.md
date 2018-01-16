# Entitas Match One
This is a simple and interactive Unity3d example project to show how to use Entitas with Psythyst Code-Generator. Entitas is a super fast Entity Component System (ECS) Framework specifically made for C# and Unity. Psythyst is a modular and extensible Code-Generator with a Unity Layer and Entitas Module.

Get Entitas here: https://github.com/sschmid/Entitas-CSharp

Get Original Match-One here:
https://github.com/sschmid/Match-One

Get Psythyst Unity Edition here: https://github.com/Psythyst/Psythyst.Core.Unity

---

Match One is a very simple CandyCrush-like Match 3 example, except it's Match One.

[Watch the talk from Unite Europe 2015](https://www.youtube.com/watch?v=1wvMXur19M4) to get an in-depth tutorial.

Match One (Psythyst Edition) shows
- systems list in GameController
- how you can use reactive system to only process changed entities
- the usage of EntityIndex for super fast entity access
- how you can use multiple pools (now refered to as ```Contexts``` in modern versions of Entitas) to reduce the memory footprint of each entity (Input, Core, Score)
- how you can create component and context definitions
- how to combine context and component definitions into a project definition
- the usage of the default project unit definitions, code generators and post processors

![Match One](https://raw.githubusercontent.com/sschmid/Entitas-CSharp/develop/Readme/Images/Match-One.png)

---

### Create a Context Definition

```
[Right Click in Asset Explorer] -> Create -> Psythyst -> Entitas -> Context Definition
```

In the field ```Context Name```, give your Context a name such as "Game" or "GameState" without a ```"Context"``` suffix. Later, when we create a Component we will add it to the Component's ```Context Definition``` field from Unity's Object Browser Menu.

![Imgur](https://i.imgur.com/mU8le48.jpg)

![Imgur](https://i.imgur.com/5g2DKP4.jpg)

---

### Create a Component Definition

```
[Right Click in Asset Explorer] -> Create -> Psythyst -> Entitas -> Component Definition
```

In the field ```Component Name```, give your component a name such as "Color" without a ```"Component"``` suffix. Add the GameContext asset we created earlier to the Component's ```Context Definition``` field. You'll notice there are multiple Contexts in the browser and two ```GameContext``` assets. This is because the Entitas-Match-One example has one which it uses to generate it's components. It will not interfere with ours, so we can just select the one we created earlier.

![Imgur](https://i.imgur.com/otPSYxc.jpg)

![Imgur](https://i.imgur.com/yv44npD.jpg)

![Imgur](https://i.imgur.com/z129drQ.png)

---

### Recommendation: Follow this tutorial in a new unity project and import: https://raw.githubusercontent.com/Psythyst/Entitas-Match-One/develop/Assets/PsythystUnity-Entitas.unitypackage

### Create Component Member(s)

Add a new member by clicking the ```"+"``` button then select the icon beside ```Type```. This dropdown is asking us whether we want to input the type by hand such as ```int``` / ```System.Int32``` or select a ScriptableObject ```Variable```. The Entitas-Match-One example comes with the full edition of Psythyst Unity Edition and includes many common member types already defined. Having to type these out every time can be annoying and error prone since we're dealing with strings; Variables help prevent mistypes.

Because we are dealing with a ```ColorComponent``` I'm going to select an Int32 type for our rgb members and give them a suitable name.

Continue adding members until you have `r` `g` and `b` and if you like, throw in an alpha channel ;)

![Imgur](https://i.imgur.com/YNYHIxA.jpg)

![Imgur](https://i.imgur.com/YTialca.jpg)

![Imgur](https://i.imgur.com/G6eRs17.jpg)

---

### Create a Project Definition

```
[Right Click in Asset Explorer] -> Create -> Psythyst -> Entitas -> Project Definition
```

When a project definition is first created it is a blank slate with no data. A Project Definition is basically a container which holds your ```Contexts``` and ```Components```. You may notice that a Project Definition expects a Project Unit Definition as well. In most day-to-day work the default Project Unit Definition will suffice but it is basically a container which holds asset instances of ```Generators``` and ```PostProcessors```. 

It comes in two "flavours", default and debug which outputs code and the latter which does not (but instead does a Debug.Log to the unity and simulates the generation: a dry-run).


Now, Add your ```Contexts``` and ```Components``` to your Project Definition and select the default Project Unit Definition.

Double click the ```Project Unit Definition``` field and it will take to the asset instance. In the Entitas-Match-One example I've changed the default generation path to be ```Assets/Sources/Generated``` to match the original project as much as possible. By default it is set to ```Assets/Generated```. (If you started in a new unity project it will be set to the default, so this part can be skipped)

We need to change it because if we don't it will overwrite our Entitas-Match-One generated code (remember to change it back later if you want to generate the Match-One definitions)

Scroll down to the ```PostProcessor Definition``` section and double click ```Default_PostProcessor_WriteToDisk``` and it will take you to the PostProcessor assetinstance. This PostProcessor has a "Folder" option which you can type in manually or select a ```Variable```. 

Double click it and Unity will take you the ```Variable```. This ```Variable``` is also used in the ```Default_PostProcessor_CleanTargetDirectory``` so if you type in a new folder path manually make sure to change it there too.

![Imgur](https://i.imgur.com/alyrMGa.jpg)

![Imgur](https://i.imgur.com/wxHRQRg.jpg)

![Imgur](https://i.imgur.com/D8B2E1v.jpg)

![Imgur](https://i.imgur.com/Xr14wbC.png)

![Imgur](https://i.imgur.com/SoVpCv8.jpg)

![Imgur](https://i.imgur.com/pjbxwX8.jpg)

![Imgur](https://i.imgur.com/Ti9MrLE.png)

---

### Generation

To generate code the code go back to the ```Project Definition``` you created and hit the ```Generate``` button or select the ```Generate``` in the menu

```
Tools -> Psythyst -> Generate
```

This menu item finds all ```Project Definitions``` in the project and calls a generate method on it. If a ```Project Unit Definition``` exists on the asset it will generate the code from defined data.

If you see an along the lines of 
```
Assets/Sources/Generated/Game/GameComponentsLookup.cs(10,21): error CS0101: The namespace `global::' already contains a definition for `GameComponentsLookup'
```

This is because our Match-One example contains a ```GameContext``` already but that is ok for the purpose of looking through the generated code. And if you remove the Match-One example project or follow this tutorial in a new project you should have no errors.
