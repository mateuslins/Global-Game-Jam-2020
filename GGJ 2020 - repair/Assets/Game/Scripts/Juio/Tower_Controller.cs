using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Controller : MonoBehaviour
{
    private AudioController audioController;
    [Header("Tower")]
    public GameObject spot;
    public GameObject bullet;
    public float time;
    public Animator towerAnim;

    public PlayerController player;
    public GameObject loadingPrefab;
    private Image loadingOutside;
    private Image loadingInside;
    private float pieces = 0f;
    private float maxPieces = 5f;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        towerAnim = GetComponent<Animator>();
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        loadingOutside = Instantiate(loadingPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        loadingInside = new List<Image>(loadingOutside.GetComponentsInChildren<Image>()).Find(img => img != loadingOutside);
    }
    Vector3 lastenemypos;
    void Update()
    {
        if (pieces >= maxPieces)
        {
            pieces = maxPieces;
            towerAnim.SetBool("isFixed", true);
            time += Time.deltaTime;

            if (time >= 1.5f)
            {
                var enemy = GameObject.FindWithTag("Enemy");
                if (enemy == null)
                {
                    time = 0;
                    return;
                }
                Instantiate(bullet, new Vector3(spot.transform.position.x, spot.transform.position.y, spot.transform.position.z), spot.transform.rotation).GetComponent<Bullet_Controller>().Enemy = enemy;
                audioController.playSfx(audioController.sfxTowerShoot, 0.5f);
                time = 0;
            }
        }

        loadingOutside.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -1.5f, 0));
        loadingInside.fillAmount = (pieces / maxPieces);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pieces += player.DropPieces();
            Debug.Log("o numero de peças na torre é " + pieces);
        }
    }
}