using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public GameObject musicAnalyzer1GO;
    public GameObject musicAnalyzer2GO;
    public GameObject musicAnalyzer3GO;

    void Update()
    {
        if (musicAnalyzer1GO.activeSelf)
        {
            MusicAnalyzer musicAnalyzer1 = musicAnalyzer1GO.GetComponent<MusicAnalyzer>();
            beatTempo = musicAnalyzer1.bpm / 60f;
        }
        else if (musicAnalyzer2GO.activeSelf)
        {
            MusicAnalyzer musicAnalyzer2 = musicAnalyzer2GO.GetComponent<MusicAnalyzer>();
            beatTempo = musicAnalyzer2.bpm / 60f;
        }
        else if (musicAnalyzer3GO.activeSelf)
        {
            MusicAnalyzer musicAnalyzer3 = musicAnalyzer3GO.GetComponent<MusicAnalyzer>();
            beatTempo = musicAnalyzer3.bpm / 60f;
        }

        transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);

    }


}
