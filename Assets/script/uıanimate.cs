using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uıanimate : MonoBehaviour
{
    public GameObject playbutton;
    bool isplaygrowing=true;
    bool istrygrowing = true;
    control ct;
    public GameObject tryagainbutton;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playbuttonani());
        StartCoroutine(tryagainbuttonani());
        ct = GameObject.Find("rocket").GetComponent<control>();
    }
    IEnumerator playbuttonani()
    {
    looperpoint:

        yield return new WaitForSeconds(0.4f);
        isplaygrowing = !isplaygrowing;
        
        goto looperpoint;

    }
    IEnumerator tryagainbuttonani()
    {
    looperpoint:

        yield return new WaitForSeconds(0.4f);
        istrygrowing = !istrygrowing;

        goto looperpoint;

    }

   
    // Update is called once per frame
    void Update()
    {
        if(ct.isgameover)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = Mathf.Lerp(1.5f, 2.5f, 0.4f);
          
        }


        if(!isplaygrowing)
        {
            playbutton.transform.localScale = Vector2.Lerp(playbutton.transform.localScale, new Vector2(0.8f, 0.8f), .2f);
        }
        else if (isplaygrowing)
        {
            playbutton.transform.localScale = Vector2.Lerp(playbutton.transform.localScale, new Vector2(1f, 1f), .2f);
        }





        if(ct.isgameover && istrygrowing)
        {
            tryagainbutton.transform.localScale = Vector2.Lerp(tryagainbutton.transform.localScale, new Vector2(1f, 1f), .2f);
            tryagainbutton.transform.rotation = Quaternion.Lerp(tryagainbutton.transform.rotation, Quaternion.Euler(0, 0, -20), .2f);
        }
        else if (ct.isgameover && !istrygrowing)
        {
            tryagainbutton.transform.localScale = Vector2.Lerp(tryagainbutton.transform.localScale, new Vector2(0.8f, 0.8f), .2f);
            tryagainbutton.transform.rotation = Quaternion.Lerp(tryagainbutton.transform.rotation, Quaternion.Euler(0, 0, 20), .2f);
        }



    }
}
