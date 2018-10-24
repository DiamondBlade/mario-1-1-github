using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goomba_animation : MonoBehaviour {
    private Animator anim;
    public float speed;
    public LayerMask isGround;
    public Transform wallHitBox;
    private bool wallHit;
    public float wallHitHeight;
    public float wallHitWidth;
    private int count;
    public Text cointext;
    public int coins;

    // Use this for initialization
    void Start () {
        count = 0;
        setcounttext();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            speed = speed * -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            coins = coins - 1;
            count = count + 1;
            setcounttext();
        }
    }
    void setcounttext()
    {
        cointext.text = "Coins: " + count.ToString();
    }
}
