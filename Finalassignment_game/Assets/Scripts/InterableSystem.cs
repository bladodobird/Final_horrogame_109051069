using UnityEngine;
using UnityEngine.Events;

namespace YIZU
{
    /// <summary>
    /// ���ʨt��
    /// </summary>
    public class InterableSystem : MonoBehaviour
    {
        [SerializeField, Header("�Ĥ@����ܸ��")]
        private DialogueDeta dialogueDeta;
        [SerializeField, Header("��ܵ�����ƥ�")]
        private UnityEvent onDiaFinish;

        [SerializeField, Header("�ҰʹD��")]
        private GameObject propAct;
        [SerializeField, Header("�Ұʫ���")]
        private DialogueDeta dataDiaAct;
        [SerializeField, Header("�Ұʫ��ܵ�����ƥ�")]
        private UnityEvent onDiaFinAfterAct;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("�e����ܨt��").GetComponent<DialogueSystem>();
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