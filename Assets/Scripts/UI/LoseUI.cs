using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    public Image[] consume;
    public Sprite[] image;
    public Text money;
    private void Start()
    {
        int l = 0;
        for(int i=0;i<13;i++)
        {
            if(GameManager.getGM.ConsumeTimesCount[i]!=0)
            {
                consume[l].sprite = image[i];
                consume[l].enabled = true;
                l++;
            }
        }
        money.text = GameManager.getGM.ConsumemoneyCount.ToString()+"元";
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
