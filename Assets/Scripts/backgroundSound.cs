using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersistentAudioPlayer : MonoBehaviour
{
    // A static variable to hold the single instance of this class
    private static PersistentAudioPlayer instance;

    void Awake()
    {
        // Check if an instance of this class already exists
        if (instance == null)
        {
            // If no instance exists, set this object as the instance
            instance = this;

            // Prevent this GameObject from being destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate GameObject
            Destroy(gameObject);
        }
    }
}
