using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : Singleton<WeaponManager>
{
    [Header("Config")]
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TextMeshProUGUI weaponManaTMP;

    public void EquipWeapon(Weapon weapon)
    {
        weaponIcon.sprite = weapon.Icon;
        weaponIcon.preserveAspect = true;
        weaponIcon.gameObject.SetActive(true);
        weaponManaTMP.text = weapon.RequiredMana.ToString();
        weaponManaTMP.gameObject.SetActive(true);
        GameManager.Instance.Player.PlayerAttack.EquipWeapon(weapon);
    }

    public void DesequiparWeapon(Weapon weapon)
    {
        weaponIcon.sprite = null;
        weaponIcon.preserveAspect = true;
        weaponIcon.gameObject.SetActive(false);
        weaponManaTMP.text = null;
        weaponManaTMP.gameObject.SetActive(false);
        //GameManager.Instance.Player.PlayerAttack.EquipWeapon(weapon);
    }
}