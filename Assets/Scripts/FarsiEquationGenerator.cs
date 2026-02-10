using UnityEngine;
using System.Collections;

public class FarsiEquationGenerator : MonoBehaviour {
    public Sprite[] numbers;
    
    public Sprite plusSign;
    public Sprite minusSign;
    public Sprite multiplySign;
    public Sprite divisionSign;
    public Sprite equalSign;
    public Sprite greaterSign;
    public Sprite lesserSign;
    public Color digitColor = Color.black;
    public Color operatorColor = Color.yellow;
    char[] operators = { '+', '-', '*', '/','=','>','<' };
    
	// Use this for initialization
	void Start () {

        //GameObject testText = convertTextToObject("12+34*87/90-9>56<65=0", .2f);
        //testText.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(10,Screen.height-12,10));

	}



    public GameObject convertTextToObject(string inputText, out Vector2 size, float scale = 1)
    {
        GameObject result = new GameObject(inputText);
        float xChild = 0;
        size=new Vector2(0,0);
        for (int i = 0; i < inputText.Length; i++)
        {
            GameObject gm = new GameObject();
            gm.AddComponent<SpriteRenderer>();
            if (char.IsNumber(inputText[i]))
            {
                int spriteIndex = int.Parse(inputText[i] + "");

                gm.GetComponent<SpriteRenderer>().sprite = numbers[spriteIndex];

            }
            else
            {
                switch (inputText[i])
                {
                    case '+':
                        gm.GetComponent<SpriteRenderer>().sprite = plusSign;
                        break;
                    case '-':
                        gm.GetComponent<SpriteRenderer>().sprite = minusSign;
                        break;
                    case '*':
                        gm.GetComponent<SpriteRenderer>().sprite = multiplySign;
                        break;
                    case '/':
                        gm.GetComponent<SpriteRenderer>().sprite = divisionSign;
                        break;
                    case '=':

                        gm.GetComponent<SpriteRenderer>().sprite = equalSign;
                        break;
                    case '>':
                        gm.GetComponent<SpriteRenderer>().sprite = greaterSign;
                        break;
                    case '<':
                        gm.GetComponent<SpriteRenderer>().sprite = lesserSign;
                        break;
                }
            }
            Shader guitext = Shader.Find("GUI/Text Shader");

            gm.GetComponent<SpriteRenderer>().material.shader = guitext;

            gm.transform.parent = result.transform;
            Vector3 locpos = new Vector3(xChild, 0, 0);
            gm.transform.localPosition = locpos;
            xChild += gm.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2 + 0.05f;
            if (gm.GetComponent<SpriteRenderer>().sprite.bounds.extents.y > size.y)
                size.y = gm.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
            if (char.IsNumber(inputText[i]))
            {
                gm.GetComponent<SpriteRenderer>().material.SetColor("_Color", digitColor);
            }
            else
            {
                gm.GetComponent<SpriteRenderer>().material.SetColor("_Color", operatorColor);
            }
        }
        result.transform.localScale = new Vector3(scale, scale, scale);
        size.x = xChild*scale;
        size.y = size.y*2 * scale;
        //width *= scale;
        return result;
    }
}
