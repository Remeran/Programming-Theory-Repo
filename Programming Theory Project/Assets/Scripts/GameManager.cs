using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private static Animal animal;
    public CinemachineVirtualCamera VirtualCamera;
    public Air sparrowPrefab;
    public Land deerPrefab;
    public Aquatic squidprefab;

    public TextMeshProUGUI descriptionText;
    // Start is called before the first frame update
    void Start()
    {
        if (animal != null)
        {
            Instantiate(animal, new Vector3(0, 0, 0), animal.transform.rotation);
            animal = FindObjectOfType<Animal>();
            descriptionText.text = animal.description;
            VirtualCamera.Follow = animal.transform;
            VirtualCamera.LookAt = animal.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame(string selectedAnimal)
    {
        if (selectedAnimal == "Sparrow")
        {
            animal = sparrowPrefab;
        }
        if (selectedAnimal == "Squid")
        {
            animal = squidprefab;
        }
        if (selectedAnimal == "Deer")
        {
            animal = deerPrefab;
        }
        SceneManager.LoadScene(2);
    }
}
