using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grog : MonoBehaviour
{
    public PlayerController player;
    public WeaponController weapon;

    public GameObject Bubble;
    public TextMeshProUGUI Speech;

    public bool lowHealth = false;
    public bool lowAmmo = false;


    void Awake()
    {
        Speech.text = "";
        Bubble.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.curHP <= 20)
        {
            lowHealth = true;
            
            
            // if(!Bubble.activeSelf)
            //     Bubble.SetActive(true);
            // Speech.text = "You\'re low on health! Find some before you die!";
        }

        if(weapon.curAmmo <= 20)
            lowAmmo = true;
    }
}
