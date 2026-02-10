using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class Equation : MonoBehaviour {
    public string equation = "";
    public float lifeTime = 4.0f;
    
    GameObject manager;
    GameObject equationObject;
    bool isSelected = false;
    [HideInInspector]
    public int evaluatedEquation = 0;
	// Use this for initialization
    //void Awake () { Destroy(gameObject, lifeTime); }
	void Start () {
        manager = GameObject.Find("Manager");
        Vector2 size;
        equationObject = manager.GetComponent<FarsiEquationGenerator>().convertTextToObject(equation,out size,.25f);
        equationObject.transform.position = transform.position + new Vector3(-.5f, -1.5f,0);
        equationObject.transform.parent = transform;
       // gameObject.AddComponent<BoxCollider2D>();
       // gameObject.GetComponent<BoxCollider2D>().size = new Vector2(size.x, size.y );
       // gameObject.GetComponent<BoxCollider2D>().center = new Vector2(size.x/2 , size.y/2 );
        solveEquation();
        //GetComponent<ParticleSystem>().enableEmission=false;
        
       
	}
    void solveEquation()
    {
        char[] operators = { '+', '-', '*', '/' };
        string[] eqParts = Regex.Split(equation, @"(\*|\+|\*|\/)");//equation.Split(operators);
        //print(eqParts.Length);
        if (eqParts.Length == 1)
        {
            evaluatedEquation = int.Parse(equation);
            
        }
        else if (eqParts.Length > 1)
        {
            switch (eqParts[1][0])
            {
                case '+':
                    evaluatedEquation= int.Parse(eqParts[0])+int.Parse(eqParts[2]);
                    break;
                case '-':
                    evaluatedEquation = int.Parse(eqParts[0]) - int.Parse(eqParts[2]);
                    break;
                case '*':
                    //print(eqParts[0] + " " + eqParts[2]);
                    evaluatedEquation = int.Parse(eqParts[0]) * int.Parse(eqParts[2]);
                    break;
                case '/':
                    evaluatedEquation = int.Parse(eqParts[0]) / int.Parse(eqParts[2]);
                    break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp() {
        IsEquationSelected = true;
        //GetComponent<ParticleSystem>().enableEmission = true;
        manager.GetComponent<GameLogic>().selectEquation(gameObject);
    }
    public bool IsEquationSelected {
        get {
            return isSelected;
        }
        set {
            isSelected = IsEquationSelected;
        }
    }
}
