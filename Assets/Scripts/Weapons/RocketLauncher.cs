using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.RocketLauncher);
    }
    public override void Fire()
    {
        if (time > weaponData.rapidSpeed)
        {
            GameObject bulletObject = PoolManager.Instance.GetRocket();
            Rigidbody rigid = bulletObject.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.velocity = new Vector3(0, 0, weaponData.bulletSpeed); // 총알속도 조절
            bulletObject.transform.position = transform.position; // MyWeapon 위치로 총알 발사
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.InitBullet();
            bullet.SetBullet(weaponData.attackDamage * WeaponManager.Instance.damageMultiplier, weaponData.piercing, weaponData.radius, weaponData.explodeActive);//플레이어 공격력 받아와야함
            time = 0;
        }
    }
}
