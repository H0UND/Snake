using Snake.Application;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField]
    private int _foodCount = 1;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private GameObject _gameObject;

    [SerializeField]
    private MeshFilter _mesh;

    [SerializeField]
    private List<Mesh> _meshes;

    private void Start()
    {
        var textMesh = gameObject.GetComponentInChildren<TextMeshPro>(); 

        int minInclusive = 1;
        int maxExclusive = 10;
        _foodCount = Random.Range(minInclusive, maxExclusive);
        _mesh.mesh = _meshes[Random.Range(0, _meshes.Count)];

        textMesh.text = _foodCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        other.GetComponent<PlayerController>().AddTail(_foodCount);

        _particleSystem.Play();
        _gameObject.SetActive(false);

        Game.Instance.UpdateScore(_foodCount);
    }
}