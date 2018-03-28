using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour {


    [SerializeField] private InputStartGameNum m_StartPopup;

    [SerializeField] private InputBonusGameNum m_BonusPopup;


    public int GetStartGameNum
    {
        get { return m_StartPopup.GameNum; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartPopupActive(bool active, System.Action action = null)
    {
        m_StartPopup.m_OnClickAction = action;
        m_StartPopup.gameObject.SetActive(active);
    }

    public void BonusPopupActive(bool active)
    {
        m_BonusPopup.gameObject.SetActive(active);
    }

}
