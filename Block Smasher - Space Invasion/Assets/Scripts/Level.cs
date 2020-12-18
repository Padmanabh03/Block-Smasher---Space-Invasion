using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakAbleBlocks;

    //cached ref
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakAbleBlocks++;
    }

    public void BlocksDestroyed()
    {
        breakAbleBlocks--;
        if(breakAbleBlocks<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
