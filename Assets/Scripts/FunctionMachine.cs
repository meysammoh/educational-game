using UnityEngine;
using System.Collections;

public class FunctionMachine : MonoBehaviour {
    public string equation="=";
    GameObject manager;
    GameObject equationObject;
    bool isSelected = false;
    public AudioClip confirmSound, errorSound;
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Manager");
        Vector2 temp ;
        equationObject=manager.GetComponent<FarsiEquationGenerator>().convertTextToObject(equation,out temp,.4f);
        equationObject.transform.position=transform.position+new Vector3(.1f,-0.3f,0);
        equationObject.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public bool solveEquation(int newequation) {
        bool result = false;
        if (equation == "")
            return true;
        string[] eqParts = new string[2];
        eqParts[0] = equation[0] + "";
        eqParts[1] = equation.Substring(1);
        //equation.Split(operators);
        
        if (eqParts.Length > 1)
        {
            switch (eqParts[0][0])
            {
                case '=':
                    if (int.Parse(eqParts[1]) == newequation) return true;
                    return false;
                case '>':
                    print(newequation + ">" + int.Parse(eqParts[1]));
                    if (newequation>int.Parse(eqParts[1])) return true;
                    return false;
                case '<':
                    if (newequation<int.Parse(eqParts[1])) return true;
                    return false;
                    
            }
        }
        return result;
    }

    void OnMouseUp()
    {
        
        GameObject solvingEquation=manager.GetComponent<GameLogic>().selectMachine(gameObject);
        if (solvingEquation != null)
        {
            IsMachineSelected = true;
            Debug.Log("Equation to solve: " + solvingEquation.GetComponent<Equation>().equation + " " + equation);
            bool isOK = solveEquation(solvingEquation.GetComponent<Equation>().evaluatedEquation);
            if (isOK)
            {
                AudioSource.PlayClipAtPoint(confirmSound, transform.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(errorSound, transform.position);
            }
            Destroy(solvingEquation); 
        }
        
    }
    public bool IsMachineSelected
    {
        get
        {
            return isSelected;
        }
        set
        {
            isSelected = IsMachineSelected;
        }
    }
}
