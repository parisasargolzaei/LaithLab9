using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThePlayerController : MonoBehaviour
{
    public static ThePlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destroy(this.gameObject);
        }
    }
    private SaveLoadManager saveLoadManager;

    private void Start()
    {
        saveLoadManager = SaveLoadManager.Instance;
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            saveLoadManager.Save();
        }
     

    }
}
