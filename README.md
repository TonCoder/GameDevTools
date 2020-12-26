# GameDevTools
A set of scripts that help make development smoother.

### SimplePoolManager
##### A simple pooling system that allows reusability and flexibility when requiring multiple instance of the same object (eg: Bullets, sounds, sparks, etc)
The ```SimplePoolManager``` script is to be attached to a GameObject on the Scene. Upon attaching the script, you will be able to add and remove items from the list in which you want to instantiate. Each _POOL_ added is its own collection.

SimplePoolManager Editor example:

![image](https://user-images.githubusercontent.com/12915760/103145427-45b91500-4708-11eb-972c-b6f017faff0b.png)

The SimplePoolManager runs as a _SINGLETON_ class, in which can be accessed by any other custom class.
The following are the actions under the SimplePoolManager:
 
| Actions | Parameters | Notes|
| --- | --- | --- |
| GetSpecificPoolItemInCollection | poolName, index | This method is overloaded with additional parameters to pass through|
| GetNextAvailablePoolItem | poolName | Grabs the next available _innactive_ pool item|
| GetRandomPoolItem | poolName | Grabs a random _innactive_ pool item. Great for random spawning or other|
| GetAllItemInACategory | poolName | Returns a list of all the items in a specific pool|
| GetAllActiveCategoryItem | poolName | Returns a list of all the items that are active on the scene (Incase you need to ...blow them up?)|
| GetPoolItemParentTransform | poolName | Returns the parent of the pool item list (Wherever the list was instatiated into as a child)|
| DoesPoolExist | poolName | Returns a _Boolean_ to inform if the specific pool exists (Great to check before creationd a new pool on the fly)|
| DoesPoolItemExist | GameObject | Checks to see if the given Game object is present on any pool (To be expanded)|
| GetAllItemInACategory | poolName | Returns a list of all the items in a specific pool|
| AddNewItemToCollection | List<PoolCollection> | Lets you add a _NEW_ pool collection to the pool list|
| DisablePoolObject | poolName, GameObject/Transform | Disables the given pool object that belongs to the provided Pool. (Overloaded Method)|
| DisableAllPoolObjects | null | Disables ALL pool objects that are active|
| DisableAllPoolObjectByCategory | poolName | Disables all pool objects that belong to a specified pool|


### Editor
- Watch_ConvertImageToSprite.cs 
 - This script "watches" for any image that is placed in a folder named "Sprite" or "Sprites" and automatically converts it to a Sprity type with default settings.

### Enums
Holds all Enumerator files that can be used to simplify comparisons or specific actions

### Abstract Classes
Holds Abstract classess that can be inherited to create simple Player/Enemy/Object properties and more.

### Tools
Holds a set of scripts that will help make some actions easier. 
- Scene Manager
- SoundFXManager
- SceneFaderScript
- DespawnAfterTie
- BlobShadowScript
- Show_Gizmo
- More to come

## Scriptable Objects
A collection of Scriptable Objects to help maintain object Data and actions.


## NOTE: ReadMe will soon be enhanced with additional information relating the scripts and their usability.


