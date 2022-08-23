using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picklerickkkk : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            A.SetActive(false);
            B.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            B.SetActive(false);
            A.SetActive(true);
        }
    }
}
