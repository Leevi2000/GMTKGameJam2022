using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public RawImage img;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        img.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressPlay()
    {
        
        SceneManager.LoadScene(1);
    }

    public void StartFader()
    {
        img.enabled = true;
        animator.SetTrigger("StartFader");
    }
}
