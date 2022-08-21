namespace MainObject;

public class Bar {
    public static TextBox TextBox = new TextBox();

    public Bar(){
        TextBox = new TextBox();
        TextBox.Size = new Size(200, 20);
        TextBox.Location = new Point(0,0);
        TextBox.AcceptsTab = false;
        TextBox.Multiline = false;
        TextBox.AppendText("Rechercher...");
        TextBox.ForeColor = Color.Gray;
        TextBox.Enter += new EventHandler(this.Enter);
        TextBox.Leave += new EventHandler(this.Leave);
        TextBox.TextChanged += new EventHandler(this.TextChanged);
    }

    private void Enter(object? sender, EventArgs e){
        if(TextBox.ForeColor == Color.Gray){
            TextBox.ForeColor = Color.Black;
            TextBox.Text = "";
        }
    }

    private void Leave(object? sender, EventArgs e){
        if(TextBox.Text == ""){
            TextBox.ForeColor = Color.Gray;
            TextBox.Text = "Rechercher...";
        }
    }

    private void TextChanged(object? sender, EventArgs e){
        if(TextBox.ForeColor != Color.Gray && TextBox.Text != "Rechercher..."){
            Main.MainForm.Instance.SeeFromString(TextBox.Text);
        }
    }
}