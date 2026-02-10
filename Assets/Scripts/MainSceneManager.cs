using UnityEngine;
using System.Collections;

public class MainSceneManager : MonoBehaviour {
    public float smokeGenerationTime = 2;
    public Transform smokeStartPlace;
    float lastSmokeInsertedTime = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float now=Time.time;
        if (now - lastSmokeInsertedTime > smokeGenerationTime)
        {
            GameObject smokeObj = (GameObject)Instantiate(Resources.Load("Prefabs/Smoke"));
            smokeObj.transform.position = smokeStartPlace.position;
            lastSmokeInsertedTime = now;
        }
	}
}
