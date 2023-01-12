using UnityEngine;

namespace YIZU
{
    /// <summary>
    /// 對話資料
    /// </summary>
    [CreateAssetMenu(menuName = "YIZU/Dialogue Data", fileName = "New Dialogue Data")] //建立素材選單
    public class DialogueDeta : ScriptableObject
    {
        [Header("對話者名稱")]
        public string dialogueName;
        [Header("對話者內容"), TextArea(2, 10)]
        public string[] dialogueContents;
    }
}