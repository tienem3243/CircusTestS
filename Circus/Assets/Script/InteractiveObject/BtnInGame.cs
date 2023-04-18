using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;

public partial class BtnInGame : MonoBehaviour
{
    [SerializeField] bool Btn_Next;
    [SerializeField] bool Btn_Restart;
    [SerializeField] bool Btn_ChoseMap;
    [SerializeField] List<Object> curents;
    [SerializeField] List<Object> goTos;
    Button button;
    [SerializeField] FadeTransitionEffect transitionEffect;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        if (Btn_Next)
            button.onClick.AddListener(UIInGameManager.Instance.NextMap);
        else
            if (Btn_Restart)
            button.onClick.AddListener(UIInGameManager.Instance.ReStartMap);
        else
            if (Btn_ChoseMap)
            button.onClick.AddListener(UIInGameManager.Instance.BackChoseMap);

        button.onClick.AddListener(btnpressEffect);
    }
    public void OnClick()
    {
        StartCoroutine(delayTransition());
        transitionEffect.transition();
    }
    IEnumerator delayTransition()
    {
        yield return new WaitForSeconds(transitionEffect.fadetime);
        foreach(GameObject item in curents)
        {
            item.gameObject.SetActive(false);
        }
        foreach(GameObject item in goTos)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void btnpressEffect()
    {
        Vector3 startPos = this.button.transform.position;
        Vector3 targetPos = startPos - new Vector3(1.5f, -2f, 0);
        this.button.transform.DOMove(targetPos, 0.05f)
            .OnComplete(() => {
                this.button.transform.DOMove(startPos, 0.05f);
            });
    }
}
