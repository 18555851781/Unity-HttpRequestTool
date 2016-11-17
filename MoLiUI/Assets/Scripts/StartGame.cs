using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load("Prefabs/TestOne") as GameObject);
        TestOne testTwo = go.GetComponent<TestOne>();
        if (testTwo == null)
        {
            testTwo = go.AddComponent<TestOne>();
        }
	}
	
	
}
