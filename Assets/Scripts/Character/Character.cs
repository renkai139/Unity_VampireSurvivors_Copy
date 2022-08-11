using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    Sprite sprite;
    RuntimeAnimatorController controller;
    Animator animator;
    int healthPoint;
    int attackPower;
    int defencePower;
    int speed;
    int maxHealth;

    internal virtual void Initialize()
    {
        healthPoint = characterData.GetHealthPoint();
        attackPower = characterData.GetAttackPower();
        defencePower = characterData.GetDefencePower();
        speed = characterData.GetSpeed();
        maxHealth = characterData.GetHealthPoint();
        sprite = characterData.GetSprite();
        controller = characterData.GetController();
        GetComponent<SpriteRenderer>().sprite = GetSprite();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = GetController();
    }

    internal void InitHealthPoint()
    {
        healthPoint = characterData.GetHealthPoint();
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    public int GetDefencePower()
    {
        return defencePower;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public RuntimeAnimatorController GetController()
    {
        return controller;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    internal Animator GetAnimator()
    {
        return animator;
    }

    public virtual void ReduceHealthPoint(int damage)
    {
        if(healthPoint <= damage)
        {
            healthPoint = 0;
            Die();
        }
        else
        {
            healthPoint -= damage;
        }
    }

    public void RecoverHealthPoint(int amount)
    {
        if (healthPoint + amount > maxHealth)
        {
            healthPoint = maxHealth;
        }
        else
        {
            healthPoint += amount;
        }
    }

    public void IncreaseAttackPower(int value)
    {
        attackPower += value;
    }

    public void IncreaseDefencePower(int value)
    {
        defencePower += value;
    }

    public void IncreaseSpeed(int value)
    {
        speed += speed * value / 100;
    }

    public CharacterData.CharacterType GetCharacterType()
    {
        return characterData.GetCharacterType();
    }

    public abstract void Die();

    internal abstract IEnumerator DieAnimation();
}