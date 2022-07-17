using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderController : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage img;
    public Animator animator;
    void Start()
    {
        img.enabled = true;
        animator.SetTrigger("CamFadeIn");
        Debug.Log("aaa");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGameFader()
    {

    }
}
