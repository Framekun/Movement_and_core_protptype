using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class AttackMove
{
    [SerializeField] private string _moveName;
    public string MoveName => _moveName;

    [SerializeField] private float _attackDelay;
    public float AttackDelay => _attackDelay;

    [SerializeField] private List<string> _prevComboMoves= new List<string>();
    public List<string> PrevComboMoves => _prevComboMoves;

    [SerializeField] private KeyCode _attackKey;
    public KeyCode AttackKey => _attackKey;

    [SerializeField] private string _animTriggerName;
    public string AnimTriggerName => _animTriggerName;

    [SerializeField] private float _staminaRedCost;
    public float StaminaRedCost => _staminaRedCost;

    [SerializeField] private bool _shouldCheckRedStamina;
    public bool ShouldCheckRedStamina => _shouldCheckRedStamina;

    [SerializeField] private float _staminaBlueCost;
    public float StaminaBlueCost => _staminaBlueCost;

    [SerializeField] private bool _shouldCheckBlueStamina;
    public bool ShouldCheckBlueStamina => _shouldCheckBlueStamina;
}
