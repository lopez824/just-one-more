using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawningOffset = 1f;
    public float cameraZoomSpeed = 0.1f;
    public float velocityScoreThreshold = 0.1f;

    private GameObject cameraTarget;
    private CinemachineVirtualCamera virtualCamera;
    private float originalZoom;

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    private int score = 0;

    private List<Rigidbody> rb_cubes;
    private Rigidbody rb_lastCube;

    private void Awake()
    {
        highScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        cameraTarget = GameObject.FindGameObjectWithTag("CameraFocus");
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        originalZoom = virtualCamera.m_Lens.OrthographicSize;

        rb_cubes = new List<Rigidbody>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            highScoreText.text = PlayerPrefs.GetString("HighScore");
    }

    public void SpawnPrefab()
    {
        GameObject cube = Instantiate(prefab, transform.position, Quaternion.identity);
        rb_cubes.Add(cube.GetComponent<Rigidbody>());
        
        float offset = transform.position.y + spawningOffset + Random.value;
        Vector3 newPosition = new Vector3(transform.position.x, offset, transform.position.z);
        transform.position = newPosition;

        Transform cameraTransform = cameraTarget.transform;
        float cameraOffset = cameraTransform.position.y + spawningOffset;
        Vector3 newCameraPosition = new Vector3(cameraTransform.position.x, cameraOffset, cameraTransform.position.z);
        cameraTarget.transform.position = newCameraPosition;

        virtualCamera.m_Lens.OrthographicSize += cameraZoomSpeed;

        score++;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
