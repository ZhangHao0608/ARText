using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCtl : MonoBehaviour {

    private GameObject MovieBtn;
    private GameObject ModelBtn;
    //private GameObject huaping;

	// Use this for initialization
	void Start () {

        MovieBtn = GameObject.Find("MovieBtn");
        ModelBtn = GameObject.Find("ModelBtn");
       //huaping = GameObject.Find("huaping_02");

        ModelBtn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HideHuaping()
    {
        //huaping.SetActive(false);
        MovieBtn.SetActive(false);
        ModelBtn.SetActive(true);
    }

    public void HideMovie()
    {
        //huaping.SetActive(true);
        MovieBtn.SetActive(true);
        ModelBtn.SetActive(false);
    }
}
