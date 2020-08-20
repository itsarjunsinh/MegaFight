using UnityEngine;

public class Enemy : MonoBehaviour, AttackManager.IAttackCharacter
{
    public AttackManager.IAttack attack1 { get; } = new AttackManager.AttackEarthquake();
    public AttackManager.IAttack attack2 { get; } = new AttackManager.AttackSlash();

    [SerializeField] private GameObject gameManagerObject;

    private Animator _animator;
    private FightManager _fightManager;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _fightManager = gameManagerObject.GetComponent<FightManager>();
    }

    public void StartAttack1()
    {
        _animator.SetTrigger(attack1.animationTag);
        _fightManager.Attack(attack1);
    }

    public void StartAttack2()
    {
        _animator.SetTrigger(attack2.animationTag);
        _fightManager.Attack(attack2);
    }

    public void EndTurn()
    {
        _fightManager.NextTurn();
    }
}