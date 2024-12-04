using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public struct FacilityShopStockView
{
    public string name;
    public uint stock;
    public FacilityShopStockView(string _name, uint _stock)
    {
        name = _name;
        stock = _stock;
    }
}

public class ShopView : MonoBehaviour
{
    [SerializeField] List<FacilityShopStockView> _facilityStocks = new();
    public FacilityShop FacilityShop { get; private set; }

    void Start()
    {
        FacilityShop = Brothel.Shops.OfType<FacilityShop>().FirstOrDefault();
    }
    void Update()
    {
        _UpdateFacilityStock();
    }

    void _UpdateFacilityStock()
    {
        if (FacilityShop == null)
        {
            FacilityShop = Brothel.Shops.OfType<FacilityShop>().FirstOrDefault();
        }
        _facilityStocks = FacilityShop.ItemStocks
            .Select(x => new FacilityShopStockView(x.ShopItem.Name, x.Stock))
            .ToList();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ShopView)), CanEditMultipleObjects]
public class ShopViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var shopView = target as ShopView;
        serializedObject.Update();
        if (shopView.FacilityShop != null)
        {
            EditorGUILayout.LabelField("Facility Shop");
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_facilityStocks"));
            if (EditorGUILayout.DropdownButton(new GUIContent(shopView.FacilityShop.CurrentItemStock.ShopItem.Name), FocusType.Keyboard))
            {
                var menu = new GenericMenu();
                var itemNames = shopView.FacilityShop.ItemStocks.Select(x => x.ShopItem.Name).ToArray();
                foreach (var index in Enumerable.Range(0, itemNames.Length))
                {
                    menu.AddItem(new GUIContent(itemNames[index]), shopView.FacilityShop.CurrentItemIndex == index, () => shopView.FacilityShop.CurrentItemIndex = index);
                }
                menu.DropDown(new Rect(Event.current.mousePosition, Vector2.zero));
            }
            if (GUILayout.Button("Buy"))
            {
                shopView.FacilityShop.BuyCurrentItem(1);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
