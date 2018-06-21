using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playcontroller : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text counttext;
    public Text wintext;

    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetText();
        wintext.text = "";
    }
    void FixedUpdate(){
        float movevertical = Input.GetAxis("Vertical");
        float movehorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        rb.AddForce(movement*speed);
    }
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("pick up")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetText();
        }
	}
    void SetText(){
        counttext.text = "Count: " + count.ToString();
        if (count>=13){
            wintext.text = "You Win!";
        }
    }

}
