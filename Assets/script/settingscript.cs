using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingscript : MonoBehaviour
{
    bool setwindow=false;
    public GameObject setwindowpanel;
    AudioSource ascs;
    public AudioClip buttonsound;
    // Start is called before the first frame update
    void Start()
    {
        ascs = GetComponent<AudioSource>();
    }


    public void setpressed()
    {
        setwindow = true;
        ascs.PlayOneShot(buttonsound);
    }


    public void exit()
    {
        setwindow = false;
        ascs.PlayOneShot(buttonsound);
    }

    // Update is called once per frame
    void Update()
    {
        if(setwindow)
        {
           
            setwindowpanel.transform.localScale = Vector2.Lerp(setwindowpanel.transform.localScale, new Vector2(1f, 1f), 0.2f);
        }
        else if (!setwindow)
        {
            setwindowpanel.transform.localScale = Vector2.Lerp(setwindowpanel.transform.localScale, new Vector2(0f, 0f), 0.2f);

        }
    }
}
