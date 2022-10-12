namespace Snake.Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject followingMe;

        private int followDistance = 4;

        private List<Vector3> _storedPositions;

        public int FollowDistance
        {
            get
            {
                return followDistance;
            }
            set
            {
                followDistance = value;
            }
        }

        public GameObject FollowMe
        {
            get
            {
                return followingMe;
            }
            set
            {
                followingMe = value;
            }
        }

        private void Awake()
        {
            _storedPositions = new List<Vector3>();
        }

        private void FixedUpdate()
        {
            if (!followingMe)
            {
                return;
            }

            if (followDistance == 0)
            {
                return;
            }

            _storedPositions.Add(transform.position);

            if (_storedPositions.Count > followDistance)
            {
                followingMe.transform.position = _storedPositions[0];
                _storedPositions.RemoveAt(0);
            }
        }
    }
}