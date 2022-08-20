namespace FormContent;

public class ButtonCreator : Button {
    public ButtonCreator(string Text = ""){
        this.Text = Text;
        this.AutoSize = true;
    }
    public void SetBackgroundColor(Color Color) => this.BackColor = Color;   
}

public class LabelCreator : Label {
    public LabelCreator(string Text = ""){
        this.Text = Text;
        this.AutoSize = true;
        this.BackColor = Color.FromArgb(0, Color.White);
    }

    public void SetColor(Color Color) => this.ForeColor = Color;
    public void SetBackgroundColor(Color Color) => this.BackColor = Color;
}

public class PanelCreator : Panel {
    public PanelCreator(Size Size, Point Location, Color Color){
        this.Size = Size;
        this.Location = Location;
        SetBackgroundColor(Color);
    }

    public void SetBackgroundColor(Color Color) => this.BackColor = Color;
}

public class ListCreator : ListView {
    public ListCreator(Rectangle Bounds){
        this.Bounds = Bounds;
        this.View = View.Details;
        this.FullRowSelect = true;
        this.GridLines = true;
        this.Sorting = SortOrder.Ascending;
        this.Columns.Add("Nom", -2, HorizontalAlignment.Left);
        this.BorderStyle = BorderStyle.None;
    }
}