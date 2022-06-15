using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RjCounter : MonoBehaviour
{
    
    private int a=0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown((KeyCode.Space))){
            a+=RjNumSet.NumT;
            Debug.Log("The number is "+a);
        }
    }
}
