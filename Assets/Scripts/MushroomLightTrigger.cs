using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomLightTrigger : MonoBehaviour
{
    [SerializeField] private Light mushroomlight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mushroomlight.enabled = true;
            Debug.Log("licht aan");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        mushroomlight.enabled = false;
        Debug.Log("Light uit");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
