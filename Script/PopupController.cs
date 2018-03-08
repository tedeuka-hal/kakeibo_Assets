using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour {


    [SerializeField] private GameObject m_StartPopup;

    [SerializeField] private GameObject m_BonusPopup;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartPopupActive(bool active)
    {
        m_StartPopup.SetActive(active);
    }

    public void BonusPopupActive(bool active)
    {
        m_StartPopup.SetActive(active);

    }
}
