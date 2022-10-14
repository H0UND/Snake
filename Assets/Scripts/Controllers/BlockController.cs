namespace Snake.Application
{
    using TMPro;
    using UnityEngine;

    public class BlockController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _box;

        [SerializeField]
        private int _hit = 1;

        [SerializeField]
        private Material _blockMaterial;

        [SerializeField]
        private MeshRenderer _meshRenderer;
        [SerializeField]
        private MeshRenderer _meshRendererTop;

        [SerializeField]
        private TextMeshPro _text;
        private readonly int MININCLUSIVE = 1;
        private readonly int MAXEXCLUSIVE = 20;

        [SerializeField]
        private AudioSource _audioSource;

        private void Start()
        {
            _hit = Random.Range(MININCLUSIVE, MAXEXCLUSIVE);
            _text.text = _hit.ToString();


            float x = _hit * 100f / MAXEXCLUSIVE;
            //_blockMaterial.color = new Color(0.01f * (100 - x), 0.01f * (100 - x), 0.01f * (100 - x));
            //_meshRenderer.materials[0] = _blockMaterial;

            var gradientVisibilityName = "Vector1_9fa582ecb22e464e8db4938be7626bf2";
            float gradient = 0.01f * (x - 20f);
            _meshRenderer.materials[0].SetFloat(gradientVisibilityName, gradient);
            _meshRendererTop.materials[0].SetFloat(gradientVisibilityName, gradient);
        }

        private void OnTriggerEnter(Collider other)
        {
            _audioSource.Play();
            other.GetComponent<PlayerController>().RemoveTail(_hit);
            _box.SetActive(false);
            _text.gameObject.SetActive(false);
            Game.Instance.UpdateScore(-_hit);
        }
    }
}