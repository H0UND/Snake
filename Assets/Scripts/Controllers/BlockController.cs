namespace Snake.Application
{
    using TMPro;
    using UnityEngine;

    public class BlockController : MonoBehaviour
    {
        [SerializeField]
        private int _hit = 1;

        [SerializeField]
        private Material _blockMaterial;
        
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private TextMeshPro _text;
        private readonly int MININCLUSIVE = 1;
        private readonly int MAXEXCLUSIVE = 20;

        private void Start()
        {
            _hit = Random.Range(MININCLUSIVE, MAXEXCLUSIVE);
            _text.text = _hit.ToString();


            float x = _hit * 100f / MAXEXCLUSIVE;
            _blockMaterial.color = new Color(0.01f * (100 - x), 0.01f * (100 - x), 0.01f * (100 - x));
            _meshRenderer.materials[0] = _blockMaterial;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<PlayerController>().RemoveTail(_hit);
            gameObject.SetActive(false);
            Game.Instance.UpdateScore(-_hit);
        }
    }
}