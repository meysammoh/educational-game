using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
    public float duration = 3,speed=3,scaleSpeed=.15f;
    float generation;
    Vector3 moveVector,scaleVector;
    //System.Random rnd ;
	// Use this for initialization
	void Start () {
        //rnd = new System.Random((int)Time.time);
        //float speedRand=((float)rnd.Next(0, 8))/100-0.04f;
        //print(Time.time+" "+speedRand);
        generation = Time.time;
        moveVector = new Vector3(0, speed, 0);

        scaleVector = new Vector3(scaleSpeed, scaleSpeed, 0);
        transform.localScale = new Vector3(.5f, .5f, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time - generation > duration)
            Destroy(gameObject);
        transform.position +=moveVector*Time.deltaTime ;
        transform.localScale += scaleVector*Time.deltaTime;
	}
}
