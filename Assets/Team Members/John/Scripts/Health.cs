using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("The amount of health that each enemy will spawn with")]
    public int startingHealth;
    [Tooltip("The current health of the enemy. Do not adjust this value in Inspector!")]
    public int currentHealth;

    public List<SkinnedMeshRenderer> meshRenderers;
    public Color colour;
    private NPCManager manager;

    private void Start()
    {
        currentHealth = startingHealth;
        manager = FindObjectOfType<NPCManager>();
    }

    public void Damage(int damage)
    {
        currentHealth = currentHealth - damage;
        foreach (SkinnedMeshRenderer meshRenderer in meshRenderers)
        {
            colour = meshRenderer.material.GetColor("_EmissionColor");
            meshRenderer.material.SetColor("_EmissionColor",Color.Lerp(colour, Color.white, 0.33f));
        }

        if (currentHealth <= 0)
        {
            manager.Die(gameObject);
        }
    }

    
}
