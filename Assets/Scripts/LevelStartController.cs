﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartController : MonoBehaviour {
    public GameObject startLevelCanvas;
    public GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPressStartLevelButton()
    {
        gameController.StartLevel();
        startLevelCanvas.SetActive(false);
    }
}
