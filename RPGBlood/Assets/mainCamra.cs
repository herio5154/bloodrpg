using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamra : MonoBehaviour
{
    public GameObject ThePlayer;
    private Vector3 traget;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        traget = new Vector3(ThePlayer.transform.position.x, ThePlayer.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, traget, movespeed * Time.deltaTime);

    }
}
