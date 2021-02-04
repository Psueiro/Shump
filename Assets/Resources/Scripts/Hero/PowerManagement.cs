public class PowerManagement
{
    Model _h;

    public PowerManagement(Model h)
    {
        _h = h;
    } 

    public void PowerManager()
    {
        if(_h.allMainShots != null)
        for (int i = 0; i < _h.allMainShots.Count; i++)
        {
            if (_h.shotType == _h.allMainShots[i] && _h.power > 30 * i + 1) PowerChanger(_h.allMainShots[i + 1], _h.allSecondaryShots[i + 1], _h.allFocusShots[i+1]);
            if (_h.shotType != _h.allMainShots[0] && _h.shotType == _h.allMainShots[i] && _h.power < 30 * i - 1) PowerChanger(_h.allMainShots[i - 1], _h.allSecondaryShots[i - 1], _h.allFocusShots[i - 1]);
        }
    }

    void PowerChanger(IShotType mainShot, IShotType secondShot, IShotType focusShot)
    {
        _h.shotType = mainShot;
        _h.secondaryShotType = secondShot;
        _h.focusShotType = focusShot;
    }

}
