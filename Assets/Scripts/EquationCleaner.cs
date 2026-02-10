using UnityEngine;
using System.Collections;

public class EquationCleaner : MonoBehaviour {
    [HideInInspector]
    public GameObject connectedEquation;
	// Use this for initialization

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "PageLeft")
        {
            GameObject.Destroy(connectedEquation);
            GameObject.Destroy(transform.parent.gameObject);
        }
    }
}
