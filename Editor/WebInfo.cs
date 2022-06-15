using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebInfo : MonoBehaviour
{
    public string ID;
    public string WebName;
    public string UrlAdress;
    public int playCount=0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt(WebName,playCount);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E)){
        //     //Application.OpenURL("http://www.google.com");
        //     Application.OpenURL(UrlAdress);
        // }
    }
    


}
