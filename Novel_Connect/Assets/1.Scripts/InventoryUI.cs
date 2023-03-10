using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;
    private void Start()
    {
        inventory = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        // GetComponentsInChildren란 좌표안에 들어가 있는 자식들이 <T> 형식을
        // 가지고 있을 경우 가지고 있는 자식들의 <T>들을 순차적으로 넣는 함수

        inventoryPanel.SetActive(activeInventory);
        inventory.onChangeItem += RedrawSlotUI;
    }

    public void RedrawSlotUI(int itemIndex)
    {
        for(int i = 0; i < inventory.items.Count; i++)
        {
            slots[i].item = inventory.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
}
