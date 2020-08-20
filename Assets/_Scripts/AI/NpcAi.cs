using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using _Scripts.Data;
using _Scripts.Util;

namespace _Scripts.AI
{
    public class NpcAi : MonoBehaviour
    {
        [SerializeField] private GameManagerX gameManager;

        private string _characterName;
        private Vector3 _startLocation;

        private AICharacterControl _agent;
        private CapsuleCollider _collider;

        private Spot _target = null;
        private Spot _previousSpot = null;
        private bool _isHostage = false;
        private bool _searchingPlayer = false;

        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<AICharacterControl>();
            _collider = GetComponent<CapsuleCollider>();
            StartCoroutine(StartMovement());
        }

        private void ClearTarget()
        {
            _previousSpot = _target;
            _target = null;
            _agent.target = transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_searchingPlayer == false && _target != null)
            {
                if (other.CompareTag(TagManager.Enemy))
                {
                    // NPC captured by Enemy; Increase collider radius
                    EnemyAi enemyAi = other.gameObject.GetComponent<EnemyAi>();
                    if (enemyAi.HasHostage())
                    {
                        _searchingPlayer = true;
                        StartCoroutine(StartMovement(true));
                    }
                    else
                    {
                        _isHostage = true;
                    }
                }
                else if (other.name.Equals(_target.Name))
                {
                    // Target reached; Get next location
                    Debug.Log("Reached Target");
                    ClearTarget();
                    StartCoroutine(StartMovement());
                }
            }
            else if (_searchingPlayer == true)
            {
                if (other.CompareTag(TagManager.Player))
                {
                    // Reached player; Show message
                    Debug.Log("Reached Player");
                    ClearTarget();
                    _searchingPlayer = false;
                    gameManager.InformPlayer();
                }
            }
        }

        IEnumerator StartMovement(bool urgent = false)
        {
            if(!urgent) yield return new WaitForSeconds(5.0f);
            if (!_isHostage)
            {
                _target = gameManager.GetRandomTargetLocation(_previousSpot, _searchingPlayer);
                print("Moving to " + _target.Name);
                _agent.target = _target.Location;
            }
        }
    }
}