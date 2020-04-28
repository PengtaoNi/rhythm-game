using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLevel : MonoBehaviour
{

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newNote = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
