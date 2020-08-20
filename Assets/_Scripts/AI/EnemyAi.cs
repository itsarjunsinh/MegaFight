using UnityEngine;
using UnityEngine.SceneManagement;
using _Scripts.Util;

namespace _Scripts.AI
{
    public class EnemyAi : MonoBehaviour
    {
        private bool _hasHostage = false;
        
        void OnTriggerEnter(Collider otherObject)
        {
            //Debug.Log("Enemy Collision with " + otherObject.tag);
            if (TagManager.Player.Equals(otherObject.tag))
            {
                Debug.Log("Starting FightScene");
                SceneManager.LoadScene(TagManager.SceneFight);
            }
        }

        // Assign hostage
        public bool HasHostage()
        {
            if (_hasHostage == false)
            {
                _hasHostage = true;
                return false;
            }
            else
            {
                return _hasHostage;
            }
        }
    }
}