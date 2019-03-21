using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClicks : MonoBehaviour
{
    public GameObject player;
    public Button Projectiles;
    public GameObject ProjectileAmount;
    public GameObject ProjectileCost;
    public Button Damage;
    public GameObject DamageAmount;
    public GameObject DamageCost;

    public Button ConcInc;
    public GameObject ConcIncAmount;
    public GameObject ConcIncCost;

    public Button MaxConc;
    public GameObject MaxConcAmount;
    public GameObject MaxConcCost;

    public Button InfPierce;
    public GameObject InfPierceAmount;
    public GameObject InfPierceCost;

    public Button ConcBar;
    public GameObject ConcBarAmount;
    public GameObject ConcBarCost;
    // Start is called before the first frame update
    void Start()
    {
        Projectiles.onClick.AddListener(ProjectileFunc);   
        Damage.onClick.AddListener(DamageFunc);   
        ConcInc.onClick.AddListener(ConcIncFunc);   
        MaxConc.onClick.AddListener(MaxConcFunc);   
        InfPierce.onClick.AddListener(InfPierceFunc);   
        ConcBar.onClick.AddListener(ConcBarFunc);   
    }
    public void ProjectileFunc()
    {
        if (player.GetComponent<PlayerUpgradeSystem>().ProjectileUpgrade()) {
            ProjectileAmount.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().projectiles + "";
            if (player.GetComponent<PlayerUpgradeSystem>().projectiles >= 5) {
                ProjectileCost.GetComponent<Text>().text = "0p";
            } else {
                ProjectileCost.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().projectilesCost + "p";
            }
        }
        Debug.Log("Heyo!");
    }
    public void DamageFunc()
    {
        if (player.GetComponent<PlayerUpgradeSystem>().DamageUpgrade()) {
            DamageAmount.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().damage + "";
            if (player.GetComponent<PlayerUpgradeSystem>().damage >= 30) {
                DamageCost.GetComponent<Text>().text = "0p";
            } else {
                DamageCost.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().damageCost + "p";
            }
        }
        Debug.Log("Heyoyo!");
    }
    public void ConcIncFunc()
    {
        if (player.GetComponent<PlayerUpgradeSystem>().concIncUpgrade()) {
            ConcIncAmount.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().concInc + "";

            if (player.GetComponent<PlayerUpgradeSystem>().concInc >= 2) {
                ConcIncCost.GetComponent<Text>().text = "0p";
            } else {
                ConcIncCost.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().concIncCost + "p";
            }
        }
        Debug.Log("Moo!");
    }
    public void MaxConcFunc()
    {
        if (player.GetComponent<PlayerUpgradeSystem>().MaxCapUpgrade()) {
            MaxConcAmount.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().MaxCap+"";

            if (player.GetComponent<PlayerUpgradeSystem>().MaxCap >= 4) { 
                MaxConcCost.GetComponent<Text>().text = "0p";
            } else {
                MaxConcCost.GetComponent<Text>().text = player.GetComponent<PlayerUpgradeSystem>().MaxCapCost+"p";
            }
        }
        Debug.Log("Ugh!");
    }
    public void InfPierceFunc()
    {
        if (player.GetComponent<PlayerUpgradeSystem>().InfPierceUpgrade()) {
            InfPierceAmount.GetComponent<Text>().text = "1";
            InfPierceCost.GetComponent<Text>().text = "0p";
        }
        Debug.Log("Running!");
    }
    public void ConcBarFunc()
    {

        if (player.GetComponent<PlayerUpgradeSystem>().ConcBarUpgrade()) { 
            ConcBarAmount.GetComponent<Text>().text = "1";
            ConcBarCost.GetComponent<Text>().text = "0p";
        }
        Debug.Log("Out!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
