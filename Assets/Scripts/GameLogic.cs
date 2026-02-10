using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
    public string[] equationList;
    public float timeBetweenSpawn = 4;
    public float hookMovingSpeed = 1;
    GameObject equationsParent;
    int alivehooks = 0;
    GameObject selectedEquation, selectedMachine;
    int lastEquationIndex = -1;
    float lastEquationSpawnTime = -1000;
    System.Random rnd = new System.Random();
    // Use this for initialization
	void Start () {
        equationsParent = new GameObject("EquationsParent");
	}
	
	// Update is called once per frame
	void Update () {
        if (lastEquationIndex < equationList.Length-1)
        {
           
            float now = Time.time;
            if (now - lastEquationSpawnTime > timeBetweenSpawn)
            {
                lastEquationIndex++;
                //create hook
                GameObject hookerComplex = (GameObject)Instantiate(Resources.Load("Prefabs/Hooker"));
                hookerComplex.transform.position = new Vector3(22.31472f, 8.532961f, 0);
                Transform hooker = hookerComplex.transform.FindChild("Candy_Pirate_Hook");
                hookerComplex.transform.FindChild("ChainJoint").GetComponent<Animator>().speed=hookMovingSpeed;
                //create bundle
                GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/Bundle"));
                go.transform.position = hookerComplex.transform.position;
                go.GetComponent<HingeJoint2D>().connectedBody = hooker.rigidbody2D;

                go.GetComponent<Equation>().equation = equationList[lastEquationIndex] ;
                go.GetComponent<Equation>().lifeTime = 15;
                go.transform.parent = equationsParent.transform;
                hooker.GetComponent<EquationCleaner>().connectedEquation = go;
                lastEquationSpawnTime = now;
            }
            
        }
	}
    public void selectEquation(GameObject newEquation) {
        if (selectedEquation != null){
            selectedEquation.GetComponent<Equation>().IsEquationSelected = false;
        }
        selectedEquation = newEquation;
        Debug.Log("new equation selected: "+selectedEquation.GetComponent<Equation>().equation);
    }
    public GameObject selectMachine(GameObject machine) {

        if (selectedEquation != null)
        {
            selectedMachine = machine;
            Debug.Log("new machine selected: " + selectedMachine.GetComponent<FunctionMachine>().equation);
            return selectedEquation;
        }
        return null;
    }
    
}
