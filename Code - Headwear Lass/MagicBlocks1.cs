using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlocks1 : MonoBehaviour {

    public bool magicBlocksActive = false;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!magicBlocksActive)
        {
            StartCoroutine("MagicBlocks");
        }
    }

    public IEnumerator MagicBlocks()
    {
        magicBlocksActive = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(2);
        magicBlocksActive = false;

    }
}
