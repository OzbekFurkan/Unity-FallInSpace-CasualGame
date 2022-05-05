using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopcntrolo : MonoBehaviour
{
    public GameObject spsh1;
    public GameObject spsh2;
    public GameObject spsh3;
    TextMeshProUGUI showcollectedstar;
    public bool isgamestarted = false;
    public GameObject shopandplay;
    public GameObject shpbtn1;// satın alınmadı 2. gemi
    public GameObject shpbtn2;// satın alındı ama seçili değil
   
    public GameObject shpbtn4;// satın alınmadı 3. gemi
    AudioSource asrcs;
    public AudioClip buttonsound;
    public AudioClip unlockship;
    // Start is called before the first frame update
    void Start()
    {
        showcollectedstar = GameObject.Find("collectedstar").GetComponent<TextMeshProUGUI>();

        asrcs = GetComponent<AudioSource>();


        if (PlayerPrefs.GetInt("selecetedship") == 0)
        {
            spsh1.SetActive(true);
            spsh2.SetActive(false);
            spsh3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("selecetedship") == 1)
        {
            spsh1.SetActive(false);
            spsh2.SetActive(true);
            spsh3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("selecetedship") == 2)
        {
            spsh1.SetActive(false);
            spsh2.SetActive(false);
            spsh3.SetActive(true);
        }



      
    }




    public void nextship()
    {
        asrcs.PlayOneShot(buttonsound);
        if (PlayerPrefs.GetInt("selecetedship") == 2)
        {
            
            PlayerPrefs.SetInt("selecetedship", -1);
        }
        if (PlayerPrefs.GetInt("selecetedship") >= -1 || PlayerPrefs.GetInt("selecetedship") < 3)
        {
            
            PlayerPrefs.SetInt("selecetedship", PlayerPrefs.GetInt("selecetedship") +1);

        }
        if (PlayerPrefs.GetInt("selecetedship") == 0)
        {
            spsh1.SetActive(true);
            spsh2.SetActive(false);
            spsh3.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("selecetedship") == 1)
        {
            spsh1.SetActive(false);
            spsh2.SetActive(true);
            spsh3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selecetedship") == 2)
        {
            spsh1.SetActive(false);
            spsh2.SetActive(false);
            spsh3.SetActive(true);
        }

    }
    public void previousship()
    {
        asrcs.PlayOneShot(buttonsound);
        if (PlayerPrefs.GetInt("selecetedship") == 0)
        {
            PlayerPrefs.SetInt("selecetedship", 3);

        }
        if (PlayerPrefs.GetInt("selecetedship") > -1 || PlayerPrefs.GetInt("selecetedship") < 4)
        {
            PlayerPrefs.SetInt("selecetedship", PlayerPrefs.GetInt("selecetedship") - 1);

        }

        if (PlayerPrefs.GetInt("selecetedship") == 0)
        {
            spsh1.SetActive(true);
            spsh2.SetActive(false);
            spsh3.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("selecetedship") == 1)
        {
            spsh1.SetActive(false);
            spsh2.SetActive(true);
            spsh3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selecetedship") == 2)
        {
            spsh1.SetActive(false);
            spsh2.SetActive(false);
            spsh3.SetActive(true);
        }

    }



    public void startgame()
    {
        

        if (PlayerPrefs.GetInt("selecetedship") == 0)
            {
                spsh1.SetActive(true);
                spsh2.SetActive(false);
                spsh3.SetActive(false);
                isgamestarted = true;
            }
            if (PlayerPrefs.GetInt("selecetedship") == 1 && PlayerPrefs.GetInt("issecondbuyed") == 1)
            {
                spsh1.SetActive(false);
                spsh2.SetActive(true);
                spsh3.SetActive(false);
                isgamestarted = true;
            }
            if (PlayerPrefs.GetInt("selecetedship") == 2 && PlayerPrefs.GetInt("isthirdbuyed") == 1)
            {
                spsh1.SetActive(false);
                spsh2.SetActive(false);
                spsh3.SetActive(true);
                isgamestarted = true;
            }
        

    }






    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("istrying") == 1)
        {
            shopandplay.transform.localScale = new Vector2(0, 0);
            startgame();
        }

        if (isgamestarted)
        {
            shopandplay.transform.localScale = Vector2.Lerp(shopandplay.transform.localScale, new Vector2(0, 0), .2f);
            GameObject.Find("planetcreator").GetComponent<planetcreator>().enabled = true;
            GameObject.Find("sounds").GetComponent<AudioSource>().enabled = true;
        }



        showcollectedstar.text = PlayerPrefs.GetInt("collectedstar") + "";


        if (PlayerPrefs.GetInt("selecetedship") == 0 )
        {
           
            shpbtn2.SetActive(true);
            shpbtn1.SetActive(false);
            shpbtn4.SetActive(false);
        }
      
        else if (PlayerPrefs.GetInt("selecetedship") == 1 && PlayerPrefs.GetInt("issecondbuyed")!=1)
        {
            shpbtn1.SetActive(true);
            shpbtn2.SetActive(false);
          
            shpbtn4.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selecetedship") == 1 && PlayerPrefs.GetInt("issecondbuyed") == 1 )
        {
            shpbtn2.SetActive(true);
            
            shpbtn4.SetActive(false);
            shpbtn1.SetActive(false);
        }
       

        else if (PlayerPrefs.GetInt("selecetedship") == 2 && PlayerPrefs.GetInt("isthirdbuyed") != 1)
        {
            shpbtn1.SetActive(false);
            shpbtn2.SetActive(false);
           
            shpbtn4.SetActive(true);
            
        }
        else if (PlayerPrefs.GetInt("selecetedship") == 2 && PlayerPrefs.GetInt("isthirdbuyed") == 1 )
        {
            shpbtn2.SetActive(true);
           
            shpbtn4.SetActive(false);
            shpbtn1.SetActive(false);

        }
      



    }




    public void secondshp()
    {
        if (PlayerPrefs.GetInt("collectedstar")>=30)
        {
            PlayerPrefs.SetInt("issecondbuyed", 1);
            PlayerPrefs.SetInt("collectedstar", PlayerPrefs.GetInt("collectedstar") - 30);
            asrcs.PlayOneShot(unlockship);
        }
    }

    public void thirdshp()
    {
        if (PlayerPrefs.GetInt("collectedstar") >= 40)
        {
            asrcs.PlayOneShot(unlockship);
            PlayerPrefs.SetInt("isthirdbuyed", 1);
            PlayerPrefs.SetInt("collectedstar", PlayerPrefs.GetInt("collectedstar") - 40);
        }

    }





   


}
