namespace CreateObject;

public class ElementNameTextBox {
    public static TextBox TextBox = new TextBox();

    public ElementNameTextBox(){
        TextBox = new TextBox();
        TextBox.Name = "TBName";
        TextBox.AcceptsTab = false;
        TextBox.Multiline = false;
        TextBox.Size = new Size(150, 20);
        TextBox.Location = new Point(100-TextBox.Size.Width/2-7, 28);
        TextBox.AppendText("Élément...");
        TextBox.ForeColor = Color.Gray;
        TextBox.Enter += new EventHandler(this.Enter);
        TextBox.Leave += new EventHandler(this.Leave);
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
            TextBox.Text = "Élément...";
        }
    }
}

public class ElementValueTextBox {
    public static TextBox TextBox = new TextBox();

    public ElementValueTextBox(){
        TextBox = new TextBox();
        TextBox.Name = "TBValue";
        TextBox.AcceptsTab = false;
        TextBox.Multiline = false;
        TextBox.Size = new Size(150, 20);
        TextBox.Location = new Point(100-TextBox.Size.Width/2-7, 85);
        TextBox.AppendText("Valeur...");
        TextBox.ForeColor = Color.Gray;
        TextBox.Enter += new EventHandler(this.Enter);
        TextBox.Leave += new EventHandler(this.Leave);
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
            TextBox.Text = "Valeur...";
        }   
    }
}