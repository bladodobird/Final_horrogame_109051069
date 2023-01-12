using UnityEngine;
using UnityEngine.Events;

namespace YIZU
{
    /// <summary>
    /// 互動系統
    /// </summary>
    public class InterableSystem : MonoBehaviour
    {
        [SerializeField, Header("第一次對話資料")]
        private DialogueDeta dialogueDeta;
        [SerializeField, Header("對話結束後事件")]
        private UnityEvent onDiaFinish;

        [SerializeField, Header("啟動道具")]
        private GameObject propAct;
        [SerializeField, Header("啟動後對話")]
        private DialogueDeta dataDiaAct;
        [SerializeField, Header("啟動後對話結束後事件")]
        private UnityEvent onDiaFinAfterAct;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                if (propAct == null || propAct.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dialogueDeta, onDiaFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDiaAct, onDiaFinAfterAct);
                }

            }

        }

        private void OnTriggerExit(Collider other)
        {

        }

        private void OnTriggerStay(Collider other)
        {

        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }

    }
}