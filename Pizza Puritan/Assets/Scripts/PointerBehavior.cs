using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehavior : MonoBehaviour
{
    public Transform target;
    public Transform camera;
    private float height = 5f;
    private float width = 9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var dir = target.position - transform.position;
        if (dir.magnitude < 10f)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        } else
        {
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
        
        
        
        
    }
}
