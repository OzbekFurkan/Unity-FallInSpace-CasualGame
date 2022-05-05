using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class planetdestroyer : MonoBehaviour
{
    GameObject spaceship;
   TextMeshProUGUI showscore;
    control ct;
    bool justonce = false;
    bool iscoreanistarted = false;
    GameObject score;
    bool iszoom = false;
    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("rocket");
       showscore= GameObject.Find("score").GetComponent<TextMeshProUGUI>();
        ct = GameObject.Find("rocket").GetComponent<control>();
        score = GameObject.Find("score");
    }

    // Update is called once per frame
    void Update()
    {
        if(spaceship.transform.position.x>transform.position.x+10)
        {
            Destroy(gameObject);
        }
        else if (spaceship.transform.position.x > transform.position.x  && spaceship.transform.position.x < transform.position.x + 10 && !justonce)
        {
            ct.score += 1;
            showscore.text = ct.score/2 + "";
            justonce = true;
            iscoreanistarted = true;
            StartCoroutine(strtani());
            
            
        }


        if (!iscoreanistarted)
        {
            score.transform.localScale = Vector2.Lerp(score.transform.localScale, new Vector2(0.8f, 0.8f), 0.01f);
           
        }
        else if (iscoreanistarted)
        {
           score.transform.localScale = Vector2.Lerp(score.transform.localScale, new Vector2(2.5f, 2.5f), 0.01f);
        }

       

    }

    IEnumerator strtani()
    {
        yield return new WaitForSeconds(0.5f);
        iscoreanistarted = false;
    }

   

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="star")
        {
            Destroy(col.gameObject);
        }
       
    }
}
