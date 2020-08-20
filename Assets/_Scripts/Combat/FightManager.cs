using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FightManager : MonoBehaviour
{
    //Configuration
    private bool _playerTurn = true;

    //Stats (Default AttackBoost: 1)
    [SerializeField] private float playerHealth = 100;
    [SerializeField] private float enemyHealth = 100;

    //Enemy Object
    [SerializeField] private GameObject enemyObject;

    //UI Elements
    [SerializeField] private GameObject attackPanel;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private GameObject resetButton;
    [SerializeField] private TextMeshProUGUI textEnemyHealth;
    [SerializeField] private TextMeshProUGUI textPlayerHealth;

    private TextMeshProUGUI _textMessage;
    private String message;
    private Enemy _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = enemyObject.GetComponent<Enemy>();
        _textMessage = messagePanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Attack(AttackManager.IAttack attack)
    {
        if (_playerTurn)
        {
            _playerTurn = false;

            message = "Player used " + attack.name + "!";
            _textMessage.text = message;
            print(message);

            enemyHealth -= attack.damage;
            textEnemyHealth.text = "Health: " + enemyHealth;

            //Hides attack list and displays message box  
            ToggleMessageBox();
        }
        else
        {
            _playerTurn = true;

            message = "Enemy used " + attack.name + "!";
            _textMessage.text = message;
            print(message);

            playerHealth -= attack.damage;
            textPlayerHealth.text = "Health: " + playerHealth;
        }
    }

    public void NextTurn()
    {
        if (playerHealth < 1 || enemyHealth < 1)
        {
            message = "Match over. Player: " + playerHealth + " Enemy: " + enemyHealth;
            print(message);

            if (enemyHealth < playerHealth)
            {
                _textMessage.text = "Player won!";
            }
            else
            {
                _textMessage.text = "Enemy won!";
            }

            resetButton.SetActive(true);
            _playerTurn = false;
            return;
        }

        if (_playerTurn)
        {
            //Hides message box and displays attack list
            ToggleMessageBox();
        }
        else
        {
            StartEnemyAttack();
        }
    }

    private void StartEnemyAttack()
    {
        int random = Random.Range(0, 2);
        print(random);
        if (random < 1)
        {
            _enemy.StartAttack1();
        }
        else
        {
            _enemy.StartAttack2();
        }
    }

    private void ToggleMessageBox()
    {
        if (_playerTurn)
        {
            attackPanel.SetActive(true);
            messagePanel.SetActive(false);
        }
        else
        {
            messagePanel.SetActive(true);
            attackPanel.SetActive(false);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}