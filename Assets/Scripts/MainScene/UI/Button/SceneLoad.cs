using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Load(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}