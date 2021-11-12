﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void OnClick()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
        }
        SceneManager.LoadScene(1);
    }
}