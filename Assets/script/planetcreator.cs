using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planetcreator : MonoBehaviour
{
    public GameObject[] planets;
    public GameObject spaceship;
    shopcntrolo spc;
    public GameObject star;
    public float creatorspeed;
    // Start is called before the first frame update
    void Start()
    {
        spc = GameObject.Find("shopcontrol").GetComponent<shopcntrolo>();
            
        
 StartCoroutine(createplane());
        StartCoroutine(createstar());

        if (PlayerPrefs.GetString("dif") == "Normal")
        {
            creatorspeed = 2;
        }
        else if (PlayerPrefs.GetString("dif") == "Best")
        {
            creatorspeed = 1;
        }

    }






    IEnumerator createplane()
    {
        
        looperpoint:

            int numb = Random.Range(0, 7);
            int numb2 = Random.Range(0, 7);
            yield return new WaitForSeconds(1f);
            float rndmy = Random.Range(3, 5);
            Instantiate(planets[numb], new Vector2(transform.position.x + 5, rndmy), transform.rotation);
            Instantiate(planets[numb2], new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1) + 5, Random.Range(rndmy - 8, rndmy - 7.5f)), transform.rotation);
            yield return new WaitForSeconds(creatorspeed);
        
            goto looperpoint;
        
    }





    IEnumerator createstar()
    {
        looperpoint:
        yield return new WaitForSeconds(5);
        float rndmy = Random.Range(2, 4);
        Instantiate(star, new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1) + 5, Random.Range(rndmy - 5, rndmy - 3f)), transform.rotation);
        goto looperpoint;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
