using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanMove : MonoBehaviour
{
     Animator humanm;
    // Start is called before the first frame update
    void Start()
    {
        humanm = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("walk");
        }
        
        if(Input.GetButtonUp("Jump"))
        {
            Debug.Log("stop");
        }
    }
}
