using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public PizzaPlacement script;
    public Text txt;
    private int pizzas;
    private string pizzasString;
    private string total;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Circle").GetComponent<PizzaPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        pizzas = script.total - script.remaining;
        pizzasString = pizzas.ToString();
        total = script.total.ToString();
        txt.text = pizzasString + "/" + total;
    }
}
