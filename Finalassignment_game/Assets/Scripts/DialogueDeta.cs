using UnityEngine;

namespace YIZU
{
    /// <summary>
    /// ��ܸ��
    /// </summary>
    [CreateAssetMenu(menuName = "YIZU/Dialogue Data", fileName = "New Dialogue Data")] //�إ߯������
    public class DialogueDeta : ScriptableObject
    {
        [Header("��ܪ̦W��")]
        public string dialogueName;
        [Header("��ܪ̤��e"), TextArea(2, 10)]
        public string[] dialogueContents;
    }
}