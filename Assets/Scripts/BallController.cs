using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField]
    public static bool GameOver = false;
    public static int plataformsCount = 0;

    [SerializeField]
    public bool showPanelGameOver = false;

    [SerializeField]
    private int coinsCounter = 0;

    [SerializeField]
    private float speed = 2f;

    private Rigidbody rigidbody;

    [SerializeField]
    private GameObject effectGetCoin;
    [SerializeField]
    private GameObject coinsSound;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private Text txtPlataforms;

    [SerializeField]
    private Canvas canvasGameOver;
    [SerializeField]
    private Canvas canvasPausedGame;


    private void Awake()
    {
        SceneManager.sceneLoaded += loadScene;
    }

    private void loadScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        GameOver = false;
    }

    void Start()
    {
        coinsCounter = PlayerPrefs.GetInt("MoedasGame");
        scoreText.text = coinsCounter.ToString();

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(speed, 0, 0);

        canvasGameOver = GameObject.FindWithTag("canvasGameOver").GetComponent<Canvas>();

        canvasGameOver.enabled = false;
        showPanelGameOver = true;

        StartCoroutine(changeSpeed());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver)
            BallMove();


        //Identifica se a bola saiu das plataformas
        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            GameOver = true;
            rigidbody.useGravity = true;
        }

        if (GameOver && showPanelGameOver)
        {
            PlayerPrefs.SetInt("MoedasGame", coinsCounter);

            txtScore.text = "Score: " + coinsCounter;
            txtPlataforms.text = "Plataforms: " + plataformsCount;

            canvasGameOver.enabled = true;
            showPanelGameOver = false;
        }

        //Atualiza texto com moedas
        scoreText.text = coinsCounter.ToString();

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
            Instantiate(effectGetCoin, transform.position, Quaternion.identity);
            Instantiate(coinsSound, transform.position, Quaternion.identity);

            coinsCounter++;
            Destroy(collider.gameObject);
        }
    }

    public void restartTheGame()
    {
        SceneManager.LoadScene("Endless");
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
