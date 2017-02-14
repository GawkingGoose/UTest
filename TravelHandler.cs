using System;
using System.Collections.Generic;

public class TravelHandler {

    private ISelectable targetSelection;
    public List<ISelectionListener> selectionListeners;

    private bool traveling = false;
    private bool docking = false;

    public TravelHandler() {
        SelectionHandler.getInstance().addSelectionListener(new TravelSelectionListener(this));
    }

    private class TravelSelectionListener: ISelectionListener {

        private TravelHandler handler;

        public TravelSelectionListener(TravelHandler handler) {
            this.handler = handler;
        }

        void ISelectionListener.travelSelection(ISelectable selection) {
            if (selection != null) {
                if (handler.targetSelection != selection) {
                    handler.targetSelection = selection;
                    handler.notifyListeners();
                }
            }
        }
    }

    public void addSelectionListener(ISelectionListener listener) {
        if (selectionListeners == null) {
            selectionListeners = new List<ISelectionListener>();
        }
        selectionListeners.Add(listener);
    }

    public void notifyListeners() {
        foreach (ISelectionListener listener in selectionListeners) {
            listener.travelSelection(targetSelection);
        }
    }

    public void setSeclection(ISelectable selection) {
        targetSelection = selection;
    }

    public ISelectable getSelection() {
        return targetSelection;
    }

    public void setTraveling(bool traveling) {
        this.traveling = traveling;
    }

    public bool isTraveling() {
        return traveling;
    }

    public void setDocking(bool docking) {
        this.docking = docking;
    }

    public bool isDocking() {
        return docking;
    }
}
