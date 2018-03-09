using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankCountController : MonoBehaviour {

    [SerializeField] private Text m_RankProbability;
    [SerializeField] private Text m_RankAllCount;
    
    private int m_TotalRankNum = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    /// <summary>
    /// 子役カウントアップ
    /// </summary>
    public void OnClickCountUp()
    {
        m_TotalRankNum++;
        ProbabilityCalculation();
    }

    /// <summary>
    /// 確率計算
    /// </summary>
    private void ProbabilityCalculation()
    {
        // 総ゲーム数の保持をどのように行うかが問題
        
    }
}
