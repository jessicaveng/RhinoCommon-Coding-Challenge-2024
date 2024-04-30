# XFrame RhinoCommon-Coding-Challenge-2024

Welcome to XFrame's RhinoCommon Coding Challenge! The aim of the challenge, beyond the standard stuff like how you apporach problems and write code, is to give you an opportuntiy to work with Rhino, the RhinoCommon API, and a taste of the work you could be expected to do. The challenge isn't suppose to be difficult or time consuming, and we've setup the repo so you can skip most of the boiler plate.

### Challenge:

The repo has a passing Rhino3D plugin, you're tasked with adding the following functionality to the plugin:

- incrementally create geometry in the model space as a `block`
- delete the last `block` created
- delete all of the `blocks` created
- report the current number of `blocks` that exist in the model space
- update `README.md` to include a paragraph that briefly explains what you implemented, as well as an estimate of how long you took.

The above functionality should be wrapped in some form of user-interface. We've included a blank WinForms form as a kickstarter, but you are welcome to use a different UI library like WPF or Eto if you're more familiar with those. You are also welcome to take a different approach to how a someone could use your plugin, i.e. buttons/commands.

The above functionality is the minimum -- feel free to add other features or functionality that you think would be interesting or improve the plugin. Some things to consider could be Rhino stuff like geometry naming, reporting other information like area or location, or coding stuff like tests, documentation, ci/cd.  

### 👉 Kick-off by forking this repo. When you're finished share with us your repo and we'll review your work. Try have fun with it!

We're interested in what you can achieve in a reasonable timeframe. If you're not able to complete all of the functionality within a reasonable time then submit wherever you get too -- we'll leave it up to you decide how little or long you want to spend on the challenge. If you're having issues specifically with Rhino or RhinoCommon itself, you can contact luke@xframe.com.au and we'll try assist -- we don't want you to spend time troubleshooting Rhino issues.

## What We're Interested In:
 - You're probably unfamiliar with Rhino, so we're keen to see how well you can jump in and figure out Rhino & RhinoCommon.
 - Code quality and structure, especially how you identify and handle edge cases.
 - What you can achieve for the time you took to take the challenge - we'll be looking at your repo commits as well as asking you to tell us how long you spent on the challenge. 
 - How you've considered how a user might interact and use your plugin.
 - Creativity!

## Some Additional Information:
__What is Rhino?__
Rhino is a CAD modelling software used across engineering, industrial design and architecture. We use Rhino to model XFrame geometry, model & document projects and manage fabrication data.

__What is RhinoCommon?__
RhinoCommon is the SDK how we use to build plugins ontop of Rhino.  McNeel, the publishers of Rhino explain RhinoCommon [here](https://developer.rhino3d.com/guides/rhinocommon/) and developer docs are [here](https://developer.rhino3d.com/api/rhinocommon/). McNeel also publish samples on [Github](https://github.com/mcneel/rhino-developer-samples/tree/8). We use the C# RhinoCommon library, but you can also develop ontop of Rhino using Python, VB or C++. You can read about the Rhino tech stack [here](https://developer.rhino3d.com/guides/general/rhino-technology-overview/). Some key concepts within RhinoCommon are:
 - **Doc** Document (commonly referred to as the Doc) is the active model space within Rhino. This layer represents objects and information related to the current Rhino document/model/file. Accessing the curernt document is achieved through a reference to `Rhino.RhinoDoc.ActiveDoc`. Its best practice to persist the active doc once its been called initially to ensure the same document is targeted for subsequent operations. We often using document/model interchangeable to refer to the active Rhino file.

 - **Geometry vs. RhinoObjects** Rhino seperates geometric operations from the Rhino Document layer. This is handled within the RhinoCommon api via `Rhino.Geometry` and `Rhino.DocObjects`. You can think of operations that utilise `Rhino.Geometry` as operating in a sandbox outside of the current model, with `Rhino.DocObjects` being used to commit the changes/geometry back to the model. An example would be using the `Rhino.Geometry.Point` `Point3d(doube x, double y, double z)` constructor to initialise a `point` and then using `Rhino.DocObjects.ObjectsTable` `AddPoint(agrs*)` method to add the point to the active document. Adding objects to the active document usually includes additional parameters such as `Attributes` - these get/set object attributes such as layer, object name, and other Rhino attribute information. Passing an `ObjectAttributes` parameter with a `LayerIndex = 1` will add the point to whatever layer is at `[1]` in the `LayerTable`. Successfully added objects will return a `GUID` of the created object.
The inverse process is used to get access to existing objects i.e. `Rhino.DocObjects` to retrieve object, pass to `Rhino.Geometry` to manipulate, and back to `Rhino.DocObjects` to commit the changes to the document. There are multiple ways of selecting objects in the existing document either by prompting the user to make the selection (using methods provided by `Rhino.Input`) or programmatically via `Find` methods provided in `Rhino.DocObjects.ObjectTable`. Which method depends on what you're trying to achieve.

 - **Redraw** Changes to the document such as adding/removing/transforming require the document viewport(s) to be refreshed. Using the above example of `AddPoint()` you call `Rhino.RhinoDoc.ActiveDoc.View.Redraw()`.

 - **Blocks versus InstanceDefinition versuse InstanceObject**: A `block` is a specific concept in [Rhino](https://www.rhino3d.com/features/blocks/) and many other CAD/3D software. Within RhinoCommon blocks are referred to as `instances`. You can find info on blocks/instances in RhinoCommon [here](https://developer.rhino3d.com/api/rhinocommon/rhino.geometry.instancedefinitiongeometry). This [sample](https://github.com/mcneel/rhino-developer-samples/blob/8/rhinocommon/cs/SampleCsCommands/SampleCsBlock.cs) shows how to create a block. You can read this article about how blocks instances are implemented in Rhino [here](https://developer.rhino3d.com/guides/opennurbs/traverse-instance-definitions/). Generally though instances follow the same logic outlined above in **Geometry vs. RhinoObjects**:

   - `Rhino.Geometry.InstanceDefinitionGeometry`: For manipulating definition geometry
   - `Rhino.Geometry.InstanceReferenceGeometry`: For manipulating reference geometry
   - `Rhino.DocObjects.InstanceObject`: Reference definition (i.e. copy) within document
   - `Rhino.DocObjects.InstanceDefinition`: Definition within document
   - `Rhino.DocObjects.Table.InstanceDefinitionTable`: Lists InstanceDefinitions within document

__What is the 'model space'?__
The Rhino document has has two 'spaces', model space and paper space. Both of these are visible through the viewport. The model space is where most geometry is drawn. Paper space is where layouts are drawns, you can think of layouts as the drafting space. 

__What is Eto?__
[Eto](https://github.com/picoe/Eto) is a cross-platform UI library that is recommended by McNeel when building UI for Rhino plugins. We use Winforms due to simplicity and are unlikely to to switch to Eto in the future, however a lot of McNeel examples use Eto. 

## Resources:

**Rhino** You can download a 90-day trial of Rhino8 via (https://www.rhino3d.com/download/). We use Rhino on windows and for this exercise most computers should be able to run Rhino.

**IDE** We use VisualStudio Community 2022 but you're welcome to use your IDE of choice.


