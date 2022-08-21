namespace MainObject;

using FormContent;

public class Panel {
    public static PanelCreator PanelObject = new PanelCreator(new Size(0, 0), new Point(0, 0), Color.Black);

    public Panel(){
        PanelObject = new PanelCreator(new Size(200, 400), new Point(0, 0), Color.Aqua);
    }
}