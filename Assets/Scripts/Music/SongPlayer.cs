using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableAudioDictionary<AudioClip, List>
{
    private List<AudioClip> clips = new List<AudioClip>();

    private List<float[]> breakpoints = new List<float[]>();

    public void Add(AudioClip audioClip, float[] listOfBreakpoints)
    {
        clips.Add(audioClip);
        breakpoints.Add(listOfBreakpoints);
    }

    public void getListOfBreakpoints(AudioClip key, List<float> output)
    {
        int index = clips.IndexOf(key);
        if (index >= 0)
        {
            float[] floats = breakpoints[index];
            foreach (float f in floats)
            {
                output.Add(f);
            }
        }


    }
}

public class SongPlayer : MonoBehaviour
{

    //set up system so that
    // - breakpoints for each music clip (list of time functions (ms)
    // - transition to the next at the right time

    [SerializeField]
    SerializableAudioDictionary<AudioClip, List<float[]>> clipsWithBreaks = new SerializableAudioDictionary<AudioClip, List<float[]>>();

    [SerializeField]
    AudioClip[] clips;

    List<float[]> breakpoints = new List<float[]>();

    

    


    // Start is called before the first frame update
    void Start()
    {

        float[] breakpointsI1 = { 0f, 1f, 2f };

        breakpoints.Add(breakpointsI1);

        float[] breakpointsI2 = { 0f, 1f, 2f };

        breakpoints.Add(breakpointsI2);

        float[] breakpointsI3A = { 0f, 1f, 2f, 3f };

        breakpoints.Add(breakpointsI3A);

        for (int i = 0; i < clips.Length; i++)
        {
            clipsWithBreaks.Add(clips[i], breakpoints[i]);
        }

        
    }

    public float getDifferenceToNearestBreak(AudioClip currentClip, float timeSinceClipStarted)
    {

        //float timeOfNearestBreak;

        List<float> breaksOfCurrentClip = new List<float>();

        clipsWithBreaks.getListOfBreakpoints(currentClip, breaksOfCurrentClip);

        float minTime = float.MaxValue;
        foreach (float breakpoint in breaksOfCurrentClip)
        {
            if (timeSinceClipStarted - breakpoint < minTime)
            {
                minTime = timeSinceClipStarted - breakpoint;
            }
        }

        return minTime;

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    //i1 -> t1 -> i2
    public void TransitionT1ToT2()
    {
        //
        //float timeDifference = getDifferenceToNearestBreak( , );

        //if timer surpasses the time difference, then

        //float timer = Time.time;
        //if (timer > timeDifference)
        //{
            
        //}
    }

    //i2 -> t2 -> t3a

    //i3a

    //i3b

    //game loss

    //game won

    //main title
}
