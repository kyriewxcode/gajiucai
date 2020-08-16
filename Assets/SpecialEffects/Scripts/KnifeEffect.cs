using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.Time;
using UnityEngine.Playables;

public enum EffectState
{
	None,
	Play,
	Close
}

public class KnifeEffect : MonoBehaviour
{

	public PlayableDirector timelinePlayable;
	public EffectState effectState;

	public GameObject[] effectsGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        effectState = EffectState.None;
		CloseEffet();
    }

    // Update is called once per frame
    void Update()
    {
		switch (effectState)
		{
			case EffectState.None:

				break;

			case EffectState.Play:
				timelinePlayable.Play();
				effectState = EffectState.None;
				break;

			case EffectState.Close:
				CloseEffet();
				effectState = EffectState.None;
				break;
		}
    }

	public void CloseEffet()
	{
		for (int i = 0; i < effectsGameObjects.Length; i++)
		{
			effectsGameObjects[i].SetActive(false);
		}
	}

}
