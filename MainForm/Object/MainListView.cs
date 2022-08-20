namespace MainObject;

using FormContent;

public class MainList {
    public static ListCreator List = new ListCreator(new Rectangle(new Point(0,0), new Size(0,0)));
    public MainList(){
        List = new ListCreator(new Rectangle(new Point(0, 21), new Size(200, 319)));
        List.MultiSelect = false;
        List.MouseHover += new EventHandler(MouseEnter);
        List.MouseDoubleClick += new MouseEventHandler(Click);
    }

    private void MouseEnter(object? sender, EventArgs e) => Cursor.Current = Cursors.Hand;

    private void Click(object? sender, MouseEventArgs e) => new ViewF.ViewForm(List.SelectedItems[0].Text).Show();
}