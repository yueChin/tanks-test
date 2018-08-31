using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2 :Tank{

    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;
        base.UnderAttack(damage);
        PlayUnderAttackEffect();
        if (mAttr.CurrentHP <= 0)
        {
            PlayDeathEffect();
            Killed();
        }
    }

    public override void Update()
    {
        base.Update();
        ShowHP();
    }

    private void PlayUnderAttackEffect() { }

    private void PlayDeathEffect()
    {
        EffectsPoolManager.PointFixedEffect(EffectType.TankExplosion.ToString(),Position,1f);
        mAudioSource.clip = mTankExplosion;
        mAudioSource.Play();
    }

    private void ShowHP()
    {
        mSlider.value = (float)Attr.CurrentHP / Attr.TotalHP;
    }
}
