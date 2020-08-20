using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using _Scripts.Data;
using _Scripts.Util;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class GameManagerX : MonoBehaviour
    {
        // Config
        private bool _messageBoxHidden = true;

        //Character Object
        [SerializeField] private GameObject playerObject;

        //UI Elements
        [SerializeField] private GameObject acceptButton;
        [SerializeField] private GameObject messagePanel;

        private TextMeshProUGUI _textMessage;
        private String _message = "NPC has been captured by the Red Monster in the woods. You must rescue him.";

        // Spots
        [SerializeField] private GameObject spots;
        private readonly List<Spot> _spotList = new List<Spot>();

        // Start is called before the first frame update
        void Start()
        {
            _textMessage = messagePanel.GetComponentInChildren<TextMeshProUGUI>();
            _textMessage.text = _message;

            for (var i = 0; i < spots.transform.childCount; i++)
            {
                _spotList.Add(new Spot(spots.transform.GetChild(i).name, spots.transform.GetChild(i)));
            }
            
            Debug.Log("Total Spots: " + _spotList.Count);
        }

        // Show message to player
        public void InformPlayer()
        {
            ToggleMessageBox();
        }

        public void AcceptQuest()
        {
            ToggleMessageBox();
        }

        private void ToggleMessageBox()
        {
            if (_messageBoxHidden)
            {
                messagePanel.SetActive(true);
                acceptButton.SetActive(true);
                _messageBoxHidden = false;
            }
            else
            {
                messagePanel.SetActive(false);
                acceptButton.SetActive(false);
                _messageBoxHidden = true;
            }
        }

        public Spot GetRandomTargetLocation(Spot currentSpot = null, bool requestPlayerLocation = false)
        {
            if (requestPlayerLocation)
            {
                return new Spot(TagManager.Player, playerObject.transform);
            }
            else
            {
                int randomNum;
                while (true)
                {
                    Random.InitState(DateTime.Now.Millisecond);
                    randomNum = Random.Range(0, _spotList.Count);
                    //Debug.Log("Random: " + randomNum);
                    if (currentSpot == null)
                    {
                        break;
                    }
                    else if (!currentSpot.Equals(_spotList[randomNum]))
                    {
                        break;
                    }
                }
                return _spotList[randomNum];
            }
        }
    }
}