using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class control : MonoBehaviour
{
    bool isup=false;
    Rigidbody2D rb;
    public GameObject menu;
    public bool isgameover = false;
    public float rocketspeed=0;
    shopcntrolo spc;
    public int score=0;
    Image plus1;
    public GameObject plas1;
    TextMeshProUGUI showbest;
    GameObject best;
    bool isbestgrowing = true;
    public GameObject bestscorecelebrate;
    public GameObject rocketsound;
    public AudioClip collectedstarsound;
    public AudioClip collapse;
    AudioSource ascs;
    public GameObject bestsound;
    int reklamsayac = 0;
    // Start is called before the first frame update
    void Start()
    {
        ascs = GetComponent<AudioSource>();
        showbest = GameObject.Find("bestscore").GetComponent<TextMeshProUGUI>();
        plus1 = plas1.GetComponent<Image>();
        best = GameObject.Find("bestscore");
        rb = GetComponent<Rigidbody2D>();
        spc = GameObject.Find("shopcontrol").GetComponent<shopcntrolo>();
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "planet")
        {
            isgameover = true;
            StartCoroutine(gameover());
            ascs.PlayOneShot(collapse, .6f);
           
        }
        else if(col.gameObject.tag=="star")
        {
            Destroy(col.gameObject);
            PlayerPrefs.SetInt("collectedstar",PlayerPrefs.GetInt("collectedstar")+1);
            StartCoroutine(setalpha());
            ascs.PlayOneShot(collectedstarsound, .6f);
        }
        
    }

  

    IEnumerator setalpha()
    {
       plas1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        plus1.color = new Color(1,1,1,0.8f);
        yield return new WaitForSeconds(0.2f);
        plus1.color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.2f);
        plus1.color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.2f);
        plus1.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        plus1.color = new Color(1, 1, 1, 0f);
        plas1.SetActive(false);
    }






    IEnumerator gameover()
    {
        rocketsound.SetActive(false);

        reklamsayac = PlayerPrefs.GetInt("reklamsayac");
        reklamsayac++;
        PlayerPrefs.SetInt("reklamsayac", reklamsayac);

        if (PlayerPrefs.GetInt("reklamsayac") % 3 == 0)
        {

            GameObject.FindGameObjectWithTag("adds").GetComponent<reklam>().reklamigoster();
            PlayerPrefs.SetInt("reklamsayac", 0);

        }

        if (score/2 > PlayerPrefs.GetInt("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", score / 2);
            StartCoroutine(bestani());
            bestsound.SetActive(true);
            bestscorecelebrate.GetComponent<ParticleSystem>().Play();

        }


        showbest.text = "Best Score         \n\n" + PlayerPrefs.GetInt("bestscore");
    looperpoint:
       Camera.main.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);

        goto looperpoint;


    }






    IEnumerator bestani()
    {
    looperpoint:

        yield return new WaitForSeconds(0.4f);
        isbestgrowing = !isbestgrowing;

        goto looperpoint;

    }





    public void tryagain()
    {
        PlayerPrefs.SetInt("istrying", 1);
        SceneManager.LoadScene("game");
        
      
    }


    public void openmenu()
    {
       PlayerPrefs.SetInt("istrying", 0);
        SceneManager.LoadScene("game");
       
       
    }







   IEnumerator soundcurve()
    {
        yield return new WaitForSeconds(0.3f);
        rocketsound.GetComponent<AudioSource>().spatialBlend = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x,Mathf.Clamp(transform.position.y,-5.5f,5.5f));

        if(spc.isgamestarted&&!isgameover)
        {
            if(PlayerPrefs.GetString("dif")=="Normal")
            {
                rocketspeed = 3;
            }
            else if (PlayerPrefs.GetString("dif") == "Best")
            {
                rocketspeed = 5;
            }

        }
        rb.velocity = transform.up*rocketspeed;
        if(Input.GetButtonDown("Fire1"))
        {
            isup = !isup;
            rocketsound.GetComponent<AudioSource>().spatialBlend = 0.5f;
            StartCoroutine(soundcurve());
        }
       else if (Input.GetButtonUp("Fire1"))
        {

           

        }
       
            if (isup&&spc.isgamestarted)
            {
              transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -45), .2f);
           
                
            }
            if (!isup&&spc.isgamestarted)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -135), .2f);
           
                
            }

        
               
               if(isgameover)
        {
            menu.transform.localScale = Vector2.Lerp(menu.transform.localScale,new Vector2(1.1f,1.1f),.2f);
            rocketspeed = 0;
            
        }




        if (!isbestgrowing)
        {
            best.transform.localScale = Vector2.Lerp(best.transform.localScale, new Vector2(0.8f, 0.8f), .2f);
        }
        else if (isbestgrowing)
        {
            best.transform.localScale = Vector2.Lerp(best.transform.localScale, new Vector2(1f, 1f), .2f);
        }



    }


   


}
