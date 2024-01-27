using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance { get; private set; }

    [SerializeField] public Rigidbody rigidBody;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;

        rigidBody = GetComponent<Rigidbody>();
    }
}
