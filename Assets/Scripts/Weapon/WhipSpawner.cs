using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipSpawner : WeaponSpawner
{
    internal override IEnumerator StartAttack()
    {
        while (true)
        {
            if(GetLevel() >= 1)
                SpawnWeapon(Direction.Self);

            if (GetLevel() >= 2)
                SpawnWeapon(Direction.Opposite);

            yield return new WaitForSeconds(GetAttackSpeed());
        }
    }

    public override void LevelUp()
    {
        IncreaseLevel();

        Debug.Log("levelUp");

        switch (GetLevel())
        {
            case 3:
                IncreaseAttackPower(5);
                break;
            case 4:
                IncreaseAttackPower(5);
                IncreaseAdditionalScale(10f);
                break;
            case 5:
                DecreaseAttackSpeed(10f);
                break;
        }
    }
}