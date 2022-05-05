using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dynamicmainmusic : MonoBehaviour
{
    AudioSource bgsound;
    public AudioSource[] normalsound;
    public Slider bgsldr;
    public Slider normalslider;
    int firstRun = 0;
    float normal;

    string graphic;
    public TextMeshProUGUI graphictext;
    public GameObject postpro;

    string dif;
    public TextMeshProUGUI diftext;

    // Start is called before the first frame update
    void Start()
    {

        dif = PlayerPrefs.GetString("dif");

        bgsound = GetComponent<AudioSource>();
        normal = PlayerPrefs.GetFloat("setnormal");
        firstRun = PlayerPrefs.GetInt("savedFirstRun");

        graphic = PlayerPrefs.GetString("graphic");

        if (firstRun == 0) // remember "==" for comparing, not "=" which assigns value
        {
            PlayerPrefs.SetFloat("setbg", 0.3f);
            PlayerPrefs.SetFloat("setnormal", 0.6f);
            //firstRun = 1;
            PlayerPrefs.SetInt("savedFirstRun", 1);
            bgsldr.value = PlayerPrefs.GetFloat("setbg");
            normalslider.value = PlayerPrefs.GetFloat("setnormal");


            PlayerPrefs.SetString("graphic","Best");
            graphictext.text = "Best";
            postpro.SetActive(true);


            PlayerPrefs.SetString("dif", "Normal");
            diftext.text = "Normal";
           

        }

        else
        {
            //Do lots of game save loading
            
bgsldr.value = PlayerPrefs.GetFloat("setbg");
            normalslider.value = normal;



           if(graphic=="Best")
            {
                graphictext.text = "Best";
                postpro.SetActive(true);
            }
            else if (graphic == "Performance")
            {
                graphictext.text = "Performance";
                postpro.SetActive(false);
            }


            if (dif == "Best")
            {
                diftext.text = "Best";
               
            }
            else if (dif == "Normal")
            {
                diftext.text = "Normal";
                
            }

        }
        
    }




    public void nextgraph()
    {
        if(graphictext.text=="Best")
        {
            graphictext.text = "Performance";
            PlayerPrefs.SetString("graphic", "Performance");
            postpro.SetActive(false);
        }
        else if (graphictext.text == "Performance")
        {
            graphictext.text = "Best";
            PlayerPrefs.SetString("graphic", "Best");
            postpro.SetActive(true);
        }
    }

    public void nextdif()
    {
        if (diftext.text == "Best")
        {
            diftext.text = "Normal";
            PlayerPrefs.SetString("dif", "Normal");
            
        }
        else if (diftext.text == "Normal")
        {
            diftext.text = "Best";
            PlayerPrefs.SetString("dif", "Best");
            
        }
    }







    // Update is called once per frame
    public void updatesound()
    {
        bgsound.volume = bgsldr.value;
        PlayerPrefs.SetFloat("setbg", bgsldr.value);
        for (int i=0;i<=4;i++)
        {
            normalsound[i].volume = normalslider.value;
           
            
        }
        PlayerPrefs.SetFloat("setnormal", normalslider.value);
    }
}
