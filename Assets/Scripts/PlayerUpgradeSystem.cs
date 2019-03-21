using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeSystem : MonoBehaviour
{
    [HideInInspector]
    public bool open = false;

    public GameObject HUD;
    public Text text;
    public GameObject ConcUI;

    [HideInInspector]
    public float concentration = 0;
    public float maxConcentration = 20;
    [HideInInspector]
    public int upgradePoints = 0;
    [HideInInspector]
    public int projectiles;
    [HideInInspector]
    public int projectilesCost = 3;
    [HideInInspector]
    public float damage;

    [HideInInspector]
    public int damageCost;

    [HideInInspector]
    public int MaxCap = 1;
    private bool InfPierce = false;
    private bool ConcBar = false;
    [HideInInspector]
    public float concInc = 1;
    [HideInInspector]
    public int concIncCost = 1;
    [HideInInspector]
    public int MaxCapCost = 2;
    private int InfPierceCost = 7;
    private int ConcBarCost = 2;



    // Start is called before the first frame update
    void Start()
    {
        damageCost = 1;
        ConcUI.SetActive(false);
        projectiles = gameObject.GetComponent<PlayerShooting>().projectiles;
        damage = gameObject.GetComponent<PlayerShooting>().damage;
    }
    public bool ProjectileUpgrade()
    {
        if (upgradePoints >= projectilesCost) {
            upgradePoints -= projectilesCost;
            projectiles += 2;
            projectilesCost += 6;
            gameObject.GetComponent<PlayerShooting>().projectiles = projectiles;
            if (projectiles >= 5)
                projectilesCost += 1000;
            return true;
        }
        return false;
    }
    public bool DamageUpgrade()
    {
        if (upgradePoints >= damageCost) {
            upgradePoints -= damageCost;
            damage += 5f;
            damageCost += 1;
            gameObject.GetComponent<PlayerShooting>().damage = damage;
            if (damage >= 30)
                damageCost += 1000;
            return true;
        }
        return false;
    }
    public bool concIncUpgrade()
    {
        if (upgradePoints >= concIncCost) {
            upgradePoints -= concIncCost;
            concInc += 0.2f;
            concIncCost += 1;

            if (concInc >= 2)
                concIncCost += 1000;
            return true;
        }
        return false;
    }
    public bool MaxCapUpgrade()
    {
        if (upgradePoints >= MaxCapCost) {
            upgradePoints -= MaxCapCost;
            MaxCap += 1;
            MaxCapCost *= 2;
            maxConcentration = MaxCap * 20;
            if(MaxCap>=4)
                MaxCapCost += 1000;
            return true;
        }
        return false;
    }
    public bool InfPierceUpgrade()
    {
        if (upgradePoints >= InfPierceCost) {
            upgradePoints -= InfPierceCost;
            InfPierce = true;
            gameObject.GetComponent<PlayerShooting>().pierce = InfPierce;
            InfPierceCost += 1000;
            return true;
        }
        return false;
    }
    public bool ConcBarUpgrade()
    {
        if (upgradePoints >= ConcBarCost) {
            upgradePoints -= ConcBarCost;
            ConcBar = true;
            ConcUI.SetActive(true);
            ConcBarCost += 1000;
            return true;
        }
        return false;
    }
    
    
    // Update is called once per frame
    void Update()
    {

        text.text = "Points: " + upgradePoints + "p";
        if (ConcBar == true) {
            if (Input.GetKeyDown(KeyCode.C) && maxConcentration >= concentration) {
                concentration += concInc;
            }
            if (concentration > 0) {
                concentration -= 0.01f;
                gameObject.GetComponent<PlayerShooting>().damage = 5f + (0.5f * concentration);
            }
            if (concentration < 0) {
                concentration = 0;
                gameObject.GetComponent<PlayerShooting>().damage = 5f + (0.5f * concentration);
            }
        }
    }
}
