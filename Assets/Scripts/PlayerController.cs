using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public List<Transform> tails;
    [Range(0, 3)] public float boneDistans;
    public GameObject bonePrefab;
    [Range(0.1f, 1)] public float speed;
    [SerializeField] GameObject boneSpawn;
    [SerializeField] GameObject foodSpawn;
    private float sizeX;
    private float sizeZ;
    [SerializeField] GameObject foodPool;
    Random random = new Random();
    private int directionMove;
    public GameObject deathScreen;
    private Transform _transform;

    #region Singleton
    public static PlayerController Insanse { get; set; }
    #endregion

    private void Start()
    {
        _transform = GetComponent<Transform>();
        directionMove = 2;
    }

    private void Update()
    {
        MoveSnake(_transform.position + transform.forward * speed * 0.1f);

        float angel = Input.GetAxis("Horizontal") * 2;
        
        _transform.Rotate(0, angel, 0);

        if (directionMove == 1)
        {
            _transform.Rotate(0, 2 * -1, 0);
           
        }
        else if (directionMove == 0)
        {
            transform.Rotate(0, 2, 0);

           
        }
        else if (directionMove == 2)
        {
            return;
        }

    }

    public void SnakeController(int pos)
    {
        directionMove = pos;
    }


    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDisatnce = boneDistans * boneDistans;
        Vector3 previosPosition = _transform.position;
        Quaternion previosRotation = _transform.rotation;
        foreach(var bone in tails)
        {
            if ((bone.position - previosPosition).sqrMagnitude > sqrDisatnce)
            {
                var temp = bone.position;
                var tempRotation = bone.transform.rotation;
                bone.rotation = previosRotation;
                bone.position = previosPosition;
                previosPosition = temp;
                previosRotation = tempRotation;
            }
            else
            {
                break;
            }
        }

        _transform.position = newPosition;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            var bone = Instantiate(bonePrefab, boneSpawn.transform);
            tails.Add(bone.transform);

            sizeX = Random.Range(-19f, 17.5f);
            sizeZ = Random.Range(-18, 19);

            collision.gameObject.transform.position = new Vector3(sizeX, 1, Random.Range(-5, 19f));

        }
        if(collision.gameObject.tag == "bone")
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
