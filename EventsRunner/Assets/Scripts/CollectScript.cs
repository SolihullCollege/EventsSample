using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectScript : MonoBehaviour
{
    MeshRenderer[] children;

    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            StartCoroutine("showHide");
        }
    }

    IEnumerator showHide()
    {
        
        foreach(MeshRenderer rend in children)
        {
            rend.enabled = false;
        }
        GetComponentInChildren<ParticleSystem>().Stop();
        yield return new WaitForSeconds(3);
        foreach (MeshRenderer rend in children)
        {
            rend.enabled = true;
        }
        GetComponentInChildren<ParticleSystem>().Play();
    }


}
