using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditModifier : Editor
{
    [MenuItem("GameObject/Tag/修改为Model标签")]
	static void TagModifierToModel()
	{
        ModifierTag("Model");
	}

    [MenuItem("GameObject/Tag/修改为Floor标签")]
	static void TagModifierToFloor()
	{
		ModifierTag("Floor");
	}

   [MenuItem("GameObject/Prefab/增加地面")]
    static void AddFloorPrefab()
	{
	  	GameObject floor = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/prefab/Cube.prefab");

		foreach (GameObject item in Selection.gameObjects)
		{
			GameObject newFloor =  PrefabUtility.InstantiatePrefab(floor)as GameObject;
            newFloor.transform.parent = item.transform;
			newFloor.transform.localPosition = Vector3.zero;
			newFloor.transform.localScale = new Vector3(80,0.005f,80);
			
		}  

	}
    





	private static void ModifierTag(string newTag)
	{
       foreach(GameObject selectedGameObject in Selection.gameObjects)
	   {
          selectedGameObject.tag = newTag;
	   }
	}
	  
}
