using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest quest1;
    [SerializeField] private Quest quest2;
    [SerializeField] private QuestManager questManager;
    private bool inZone = false;

    private void Update()
    {
        if (inZone == true && Input.GetKeyDown(KeyCode.F))
        {
            questManager.QuestGive(quest1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = false;
        }
    }
}


[System.Serializable]
public class Quest
{
    public string name;
    public string description;
    public int revard;
}

