using UnityEngine;
using System.Collections;


public class Path : MonoBehaviour {

    public bool contact_done;
    public GameObject Pipes;

    


	// Use this for initialization
	void Start () {
        contact_done = false;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(contact_done)
        {
            
            Invoke("Forward", 3.5f); //saniye aralığı ile güncelleme ekledi fonksiyona 
            contact_done = false; //sürekli işlem gerçeleşmesini engelledi
        }
	}


    void Forward() // ileri atama döngüsü
    {

        transform.position = transform.position + new Vector3(55, 0, 0);

        //en az -2 olacak yükseklik
        //en çok 3.5 olacak yükseklik

        float Y_Position = Random.Range(-0.6f, 3.8f);

        Pipes.transform.localPosition = new Vector3(0, Y_Position,1.94f);
        
    }
}
