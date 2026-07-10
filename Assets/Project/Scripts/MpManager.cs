using UnityEngine;
using UnityEngine.UI;

public class MpManager : MonoBehaviour{
    [Header("MP設定")]
    [SerializeField] private int maxMp = 100;
    
    [Header("UI設定")]
    [SerializeField] private Slider mpSlider;
    private int currentMp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
    currentMp = maxMp;   
    if (mpSlider != null)
        {
            mpSlider.maxValue = maxMp; // スライダーの最大値をmaxMp(100)に設定
            mpSlider.value = currentMp; // スライダーの現在値を現在のMPに設定
        } 
    }

    // Update is called once per frame
    /// <summary>
    /// MPを消費する関数。消費できたらtrue、足りなければfalseを返す。
    /// </summary>
    public bool ConsumeMp(int amount){
        // MPが足りているかチェック
        if (currentMp >= amount){
            currentMp -= amount;
            Debug.Log($"MPを {amount} 消費しました。残りMP: {currentMp}");
            UpdateMpSlider();
            return true; // 消費成功！
        }
        else{
            Debug.Log("MPが足りません！");
            return false; // MP不足で失敗
        }
    }
    private void UpdateMpSlider()
    {
        if (mpSlider != null)
        {
            mpSlider.value = currentMp;
        }
        else
        {
            // ★アタッチされていない場合はここに警告が出る
           
        }
    }
}