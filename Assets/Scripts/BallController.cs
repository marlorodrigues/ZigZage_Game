using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    public static bool GameOver = false;
    private Rigidbody rigidbody;
    [SerializeField]
    private int coinsCounter = 0;
    public static int plataformsCount = 0;

    public Text speedText;
    public Text scoreText;
    public Text plataformText;




    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(speed, 0, 0);

        StartCoroutine(changeSpeed());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            BallMove();


        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            GameOver = true;
            rigidbody.useGravity = true;
        }


        //if (GameOver)
        //Debug.Log("Caindoooooo");

        speedText.text = "Speed: " + speed.ToString();
        scoreText.text = "Score: " + coinsCounter.ToString();
        plataformText.text = "Pass: " + plataformsCount.ToString();


        Debug.DrawRay(transform.position, Vector3.down, Color.yellow);

    }

    void BallMove()
    {
        if (rigidbody.velocity.x > 0)
        {
            rigidbody.velocity = new Vector3(0, 0, speed);
        }
        else if (rigidbody.velocity.z > 0)
        {
            rigidbody.velocity = new Vector3(speed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Coin"))
        {
            coinsCounter++;
            Destroy(collider.gameObject);
        }
    }

    IEnumerator changeSpeed()
    {
        while (!GameOver)
        {
            yield return new WaitForSeconds(8f);

            speed += 0.2f;

        }
    }
}
