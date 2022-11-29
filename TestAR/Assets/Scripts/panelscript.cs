using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 



public class panelscript : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    int counter;
   
    public void showhidePanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            Panel1.SetActive (false);
            Panel2.SetActive (true);
            

        }
        else{
            Panel1.SetActive (true);
            Panel2.SetActive (false);
        }

    }

}
