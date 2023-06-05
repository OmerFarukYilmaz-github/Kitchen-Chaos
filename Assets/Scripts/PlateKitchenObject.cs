using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }
    

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    protected override void Awake()
    {
        base.Awake();
        kitchenObjectSOList = new();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            if (kitchenObjectSOList.Contains(kitchenObjectSO))
            {
                return false;
            }
            else
            {
                kitchenObjectSOList.Add(kitchenObjectSO);
                OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
                {
                    kitchenObjectSO = kitchenObjectSO
                });

                return true;
            }
        }
        else
        {
            return false;
        }

    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
