using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picklerick : MonoBehaviour
{
    public Sprite A;
    public Sprite B;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<SpriteRenderer>().sprite = A;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<SpriteRenderer>().sprite = B;
        }

    }
}
