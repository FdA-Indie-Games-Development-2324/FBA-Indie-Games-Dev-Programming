using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeExample : MonoBehaviour
{
    public GameObject Line1, Line2, Line3, Line4, Line5;
    public int invokeTimer;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Show1", invokeTimer);
        Line1.SetActive(true);
    }

    void Show1()
    {
        Line2.SetActive(true);
        Invoke("Show2", invokeTimer);
    }
    void Show2()
    {
        Line3.SetActive(true);
        Invoke("Show3", invokeTimer);
    }
    void Show3()
    {
        Line4.SetActive(true);
        Invoke("Show4", invokeTimer);
    }
    void Show4()
    {
        Line5.SetActive(true);
        
    }


    
}
