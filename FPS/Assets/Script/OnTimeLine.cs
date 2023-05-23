using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OnTimeLine : MonoBehaviour
{
    [SerializeField] private PlayableDirector pd;

    private void Start()
    {
        pd.Play();
    }
}
