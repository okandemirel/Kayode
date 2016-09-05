
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;






public class Bird : MonoBehaviour {
   
    public float speed;
    public float jumpPower;
    public int point;
    public GameObject canvas;
    public GameObject danger;
    

   
    public Text ScoreText;
    public Text HighScore;

    public AudioClip[] sounds;
    public GameObject gus;
    int rastgele;

    public int flag = 0;

	
	void Start () {
        
        jumpPower = 0;
        speed = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Invoke("Startfunc",1.9f);
        GetComponent<AudioSource>().PlayOneShot(sounds[0], 1);
        canvas.SetActive(false);
        Time.timeScale = 1;
        point = 0;
        rastgele = Random.Range(20,40);
        Invoke("Danger", rastgele-3);
        Invoke("Reverse",rastgele);
    }

    
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
            if (Input.GetMouseButtonDown(0))
            {
                
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);

            }
    }


    void OnTriggerEnter2D(Collider2D contact)
    {
        if (contact.gameObject.tag=="Trigger")
        {

            
           
            contact.gameObject.transform.parent.root.gameObject.GetComponent<Path>().contact_done = true; 
            point++;
            GetComponent<AudioSource>().PlayOneShot(sounds[1],1);

        }
        }

    void OnCollisionEnter2D(Collision2D contact )
    {
        if (contact.gameObject.tag == "Obstacle")
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().PlayOneShot(sounds[2], 1);
        canvas.SetActive(true);
        ScoreText.text = point.ToString();

        if (point > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", point);

        }


        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void Startfunc()
    {
        
            jumpPower = 450;
            speed = -7;
            GetComponent<Rigidbody2D>().gravityScale = 1.6f;
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);

            

        
    }
   
    
    public void RestartButton()
    {
        SceneManager.LoadScene("TheSillyBird");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Danger()
    {
    danger.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
    }
    void Reverse()
    {
        danger.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GetComponents<Image>();
        jumpPower *= -1;
        GetComponent<Rigidbody2D>().gravityScale *= (-1);
        Invoke("Danger", rastgele-13);
        Invoke("ReReverse", rastgele-10);
        

    }
    void ReReReverse()
    {
        danger.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GetComponents<Image>();
        jumpPower *= -1;
        GetComponent<Rigidbody2D>().gravityScale *= (-1);
        Invoke("Danger", rastgele-18);
        Invoke("ReReverse", rastgele - 15);

    }

    void ReReverse()
    {
        danger.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GetComponents<Image>();
        jumpPower *= -1;
        GetComponent<Rigidbody2D>().gravityScale *= (-1);
        Invoke("Danger", rastgele-18);
        Invoke("ReReReverse", rastgele - 15);
    }
    
}


