using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour {

    public GameObject UI;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private FloorTiles target;

    public void SetTarget(FloorTiles _target)
    {
        this.target = _target;

        transform.position = target.GetCreatePosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.unitBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.unitBlueprint.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeUnit();
        BuildManager.instance.DeselectTile();
    }

    public void Sell()
    {
        target.SellUnit();
        BuildManager.instance.DeselectTile();

    }
}
