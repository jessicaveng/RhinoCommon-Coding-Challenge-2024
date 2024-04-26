# XFrame RhinoCommon-Coding-Challenge-2024

Welcome to XFrame's RhinoCommon Coding Challenge! The aim of the challenge, beyond the standard stuff like how you apporach problems and write code, is to give you an opportuntiy to work with Rhino, the RhinoCommon API, and a taste of the work you could be expected to do. The challenge isn't suppose to be difficult or time consuming, and we've setup the repo so you can skip most of the boiler plate.

### Challenge:

The repo has a passing Rhino3D plugin, you're tasked with adding the following functionality to the plugin:

- incrementally create geometry in the model space as a `block`
- delete the last `block` created
- delete all of the `block`s created
- report the current number of `block`s that exist in the model space

The above functionality should be wrapped in some form of user-interface. We've included a blank WinForms form as a kickstarter, but you are welcome to use a different UI library like WPF or Eto if you're more familiar with those. You can also take a different approach to how a someone could use your plugin, i.e. buttons/commands.

The above functionality is the minimum -- feel free to add other features or functionality that you think would be interesting or improve the plugin. Some things to consider could be Rhino stuff like geometry naming, reporting other information like area or location, or coding stuff like testing, documentation, ci/cd.  

Kick-off by forking this repo, when you're finished share with us your repo and we'll take a look. Try have fun with it!

We're interested in what you can achieve in a reasonable timeframe. If you're not able to complete all of the functionality within a reasonable time then submit wherever you get too -- we'll leave it up to you decide how little or long you want to spend on the challenge. If you're having issues specifically with Rhino or RhinoCommon itself, you can contact luke@xframe.com.au and we'll try assist -- we don't want you to spend time troubleshooting Rhino issues.

## What We're Interested In:
 - You're probably unfamiliar with Rhino, so we're keen to see how well you can jump in and figure out RhinoCommon.
 - Code quality and structure, especially how you handle edge cases.
 - What you can achieve over a timeframe, we'll look at the repo commits as well as ask how long you spent. 
 - Consideration for how someone might use the plugin.
 - Creativity!

## Some Additional Information:
__What is Rhino?__
Rhino is a CAD modelling software used across engineering, industrial design and architecture. We use Rhino to model XFrame geometry, model & document projects and manage fabrication data.

__What is RhinoCommon?__
RhinoCommon is the SDK how we use to build plugins ontop of Rhino.  McNeel, the publishers of Rhino explain RhinoCommon [here](https://developer.rhino3d.com/guides/rhinocommon/) and developer docs are [here](https://developer.rhino3d.com/api/rhinocommon/). McNeel also publish samples on [Github](https://github.com/mcneel/rhino-developer-samples/tree/8). We use the C# RhinoCommon library, but there are also python, VB and C++ apis. 

__What is a block?__
A `block` is a specific concept in [Rhino](https://www.rhino3d.com/features/blocks/). You can find info on blocks in RhinoCommon [here](https://developer.rhino3d.com/api/rhinocommon/rhino.geometry.instancedefinitiongeometry). This [sample](https://github.com/mcneel/rhino-developer-samples/blob/8/rhinocommon/cs/SampleCsCommands/SampleCsBlock.cs) shows how to create a block.  

__What is the 'model space'?__
Rhino has two 'spaces', model space and layout space. Both of these are visible through the viewport. The model space is where most geometry is modelled/drawn.

__What is Eto?__
[Eto](https://github.com/picoe/Eto) is a cross-platform UI library that is recommended by McNeel when building UI for Rhino plugins. We use Winforms due to simplicity and are unlikely to to switch to Eto in the future, however a lot of McNeel examples use Eto. 

## Resources:

**Rhino** You can download a 90-day trial of Rhino8 via (https://www.rhino3d.com/download/). We use Rhino on windows and for this exercise most computers should be able to run Rhino.


