using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadtrigger : MonoBehaviour
{
    [SerializeField] private SceneField[] _scenesToLoad;
    [SerializeField] private SceneField[] _scenesToUnload;

    private GameObject _Player;

    private void Awake() 
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }
 
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject == _Player)
        {
            Debug.Log("호출");
            LoadScenes();
            UnloadScenes();
        }
    }    

    private void LoadScenes()
    {
        Debug.Log("LoadScenes");
        for (int i = 0; i < _scenesToLoad.Length; i++)
        {
            bool isSceneLoaded = false;
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == _scenesToLoad[i].SceneName)
                {
                    isSceneLoaded = true;
                    break;
                }
            }

            if (!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(_scenesToLoad[i], LoadSceneMode.Additive);
            }
        }
    }
    private void UnloadScenes()
    {
        Debug.Log("UnloadScenes");
        for (int i = 0; i < _scenesToUnload.Length; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == _scenesToUnload[i].SceneName)
                {
                    SceneManager.UnloadSceneAsync(_scenesToUnload[i]);
                }
            }    
        }
    }
}
