using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour
{
     private float FadeMath = 0.1f;

    private Vector3 Scale = Vector3.zero;

    public GameObject Tile;

    private SceneLoad SL;

    void Awake()
    {
        Tile = gameObject;
        SL = this.gameObject.transform.parent.GetComponent<SceneLoad>();

        Vector3 Scale = Vector3.zero;
    }

    //FadeInパネル開始
    public void FadeInStart()
    {
        Tile.SetActive(true);
            StartCoroutine(FadeIn()); 
    }
    
    //FadeOutパネル開始
    public void FadeOutStart()
    {
            StartCoroutine(FadeOut()); 
    }

    //FadeOutパネル
    private IEnumerator FadeOut()
    {
        while (true){
            if(transform.localScale.y <= 0){
                Tile.SetActive(false);
                SL.FadeEndTiles++;
                yield return null;
            }
            Scale.y = FadeMath;
            Tile.transform.localScale -= Scale;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    //FadeInパネル
    private IEnumerator FadeIn()
    {
        Tile.SetActive(true);
        while (true){
            if(transform.localScale.y >= 1){
                SL.FadeEndTiles++;
                break;
            }
            Scale.y = FadeMath;
            Tile.transform.localScale += Scale;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
