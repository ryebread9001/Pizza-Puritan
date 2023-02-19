using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlacement : MonoBehaviour
{
    private float posX;
    private float posY;
    private List<Vector2> places = new List<Vector2>();
    public int score = 0;
    public int total;
    public int remaining;
    //private List<Vector2> placesHistory = new List<Vector2>();
    public GameObject[] respawns;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        int count = 0;
        
        foreach (GameObject respawn in respawns)
        {
            Debug.Log("respawn #" + count.ToString());
            count++;
            Vector2 pos = new Vector2();
            pos.x = respawn.transform.position.x;
            pos.y = respawn.transform.position.y;
            places.Add(pos);
        }
        total = places.Count;
        remaining = total;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(places.Count);
        Vector2 newPos = new Vector2();
        if (col.tag == "Player")
        {
            int index = Random.Range(0, places.Count - 1);
            if (places.Count > 0)
            {
                newPos = places[index];
                places.RemoveAt(index);
                Debug.Log("There are " + places.Count.ToString() + " places left...");
                score = total - places.Count;
                remaining = places.Count;
                newPos.y += 0.6f;
                transform.position = newPos;
            }
            
            

        }
    }
}
