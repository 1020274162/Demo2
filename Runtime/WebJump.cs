using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebJump : MonoBehaviour
{
    private GameObject player;
    private GameObject go;
    private WebInfo webinfo;
    private Ray ray;
    private RaycastHit hit;
    private float dis;
    private GameObject Eui;
    private Text EuiText;
    private bool isT=false;
    private bool isD=false;
    private float timer = 1.0f;
    private GameObject Temporygo;
    
    // Start is called before the first frame update
    void Start()
    {
        Eui=GameObject.Find("rjPressE");
        EuiText=Eui.GetComponent<Text>();
        Eui.SetActive(false);
        
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        player=GameObject.FindWithTag("Player");

        ray=Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit)){
                go=hit.collider.gameObject;
                if(go.tag == "Ads"){
                    
                    dis=(go.transform.position-player.transform.position).magnitude;
                    if(dis<3f){
                        EuiText.text="Press and hold E to jump to "+ go.GetComponent<WebInfo>().WebName;
                        Eui.SetActive(true);
                        isT=true;
                        if(Input.GetKey(KeyCode.E)){
                            Temporygo=go;
                            timer-= Time.deltaTime;
                                if(timer<=0&&isD==false){
                                    Application.OpenURL(go.GetComponent<WebInfo>().UrlAdress);
                                    go.GetComponent<WebInfo>().playCount+=1;
                                    OutputData();
                                    //PlayerPrefs.SetInt(go.GetComponent<WebInfo>().WebName,go.GetComponent<WebInfo>().playCount+1);
                                    isD=true;
                                }
                                //Application.OpenURL("http://www.google.com");  
                            }else{
                                isD=false;
                                timer = 1.0f;
                            }
                        
                        
                    }
                }else{
                    if(isT==true){
                        Eui.SetActive(false);
                        isT=false;
                    }

                }
                    
            }

    }
    void OutputData(){
        if(PlayerPrefs.GetInt(Temporygo.GetComponent<WebInfo>().WebName)==0){
            PlayerPrefs.SetInt(Temporygo.GetComponent<WebInfo>().WebName,Temporygo.GetComponent<WebInfo>().playCount);
        }else{
            int m=PlayerPrefs.GetInt(Temporygo.GetComponent<WebInfo>().WebName);
            PlayerPrefs.SetInt(Temporygo.GetComponent<WebInfo>().WebName,m+=1);
        }
        Debug.Log(Temporygo.GetComponent<WebInfo>().ID+" played "+PlayerPrefs.GetInt(Temporygo.GetComponent<WebInfo>().WebName));
    }
}
