using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musics = GameObject.FindGameObjectsWithTag("MenuMusic");
        if (musics.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Audrey"){
            Destroy(gameObject);
        }
    }
}
