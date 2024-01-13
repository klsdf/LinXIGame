using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 血条缓动 : MonoBehaviour
{
    private float speed = 2f;
    private float targetHealth = 1;
    private float currentHealth;
    private Slider healthBarSlider;

    void Start()
    {
        healthBarSlider = GetComponent<Slider>();
        currentHealth = healthBarSlider.value;
    }

    void Update()
    {
        currentHealth = Mathf.Lerp(currentHealth, targetHealth, speed * Time.deltaTime);
        healthBarSlider.value = currentHealth;
    }

    public void SetHealth(float health)
    {
        targetHealth = health;
    }
}
