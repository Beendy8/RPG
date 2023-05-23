using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textQuest;
    public Quest curntQuest;

    public void QuestGive(Quest q)
    {
        curntQuest = q;
        textQuest.text = "<b>" + curntQuest.name + "</b>\n" + curntQuest.description + "\nНаграда: " + curntQuest.revard;
    }
}


