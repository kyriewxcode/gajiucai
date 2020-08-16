using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertisementEffect : MonoBehaviour
{

	public GameObject[] effectsGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        CloseEffet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void CloseEffet()
	{
		for (int i = 0; i < effectsGameObjects.Length; i++)
		{
			effectsGameObjects[i].SetActive(false);
		}
	}

}
