using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foolow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.125f;
    public Vector3 offset;
    shopcntrolo spc;
    
    // Start is called before the first frame update
    void Start()
    {
        spc = GameObject.Find("shopcontrol").GetComponent<shopcntrolo>();
        StartCoroutine(trydebug());
        

    }




    IEnumerator startshake()
    {
        if (spc.isgamestarted)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45), .1f);
            yield return new WaitForSeconds(0.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45), .1f);
            yield return new WaitForSeconds(0.2f);
        }
    }


    IEnumerator trydebug()
    {
       
            yield return new WaitForSeconds(0.2f);
        PlayerPrefs.SetInt("istrying", 0);
    }


  



    void Update()
    {
      
        if (Input.GetButtonDown("Fire1"))
        {
StartCoroutine(startshake());
            
        }
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        if (spc.isgamestarted)
        {
            Vector3 desiredposition = target.position + offset;
            Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
            transform.position = smoothedposition;
            transform.LookAt(target);
        }
    }
}
