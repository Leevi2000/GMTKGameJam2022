using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MasterVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private string _volumeParameter = "MasterVolume";
    [SerializeField]
    float targetFloat;
    [SerializeField]
    float currentFloat;
    public void Awake()
    {
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //mixer = GetComponent<AudioMixer>();
        bool x = mixer.GetFloat(_volumeParameter, out targetFloat);
        mixer.SetFloat(_volumeParameter, -80);
        //mixer.ClearFloat(_volumeParameter);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        bool gotFloat = mixer.GetFloat(_volumeParameter, out currentFloat);
        if (currentFloat < targetFloat)
        {
            mixer.SetFloat(_volumeParameter, (currentFloat + Mathf.Sqrt(Mathf.Abs(currentFloat)/12)));
        }
    }
}
