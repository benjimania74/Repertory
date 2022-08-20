namespace ViewF;

using FormContent;

public class ViewForm : Form {
    private TextBox KeyContainer;
    private TextBox ValueContainer;
    private ButtonCreator DeleteButton;
    private ButtonCreator SaveButton;
    private string DefaultValue;

    public ViewForm(string Title){
        Text = Title;
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(250, 140);
        Icon = new Icon(@"./icon.ico");

        DefaultValue = Main.MainForm.Instance.GetValue(Title.Replace(":", "|.|")).Replace("|.|", ":");

        KeyContainer = new TextBox();
        KeyContainer.AppendText(Title);
        KeyContainer.Size = new Size(180, 20);
        KeyContainer.Location = new Point(Size.Width/2-KeyContainer.Width/2-7, 8);
        KeyContainer.AcceptsTab = false;
        KeyContainer.Multiline = false;

        ValueContainer = new TextBox();
        ValueContainer.Size = new Size(180, 20);
        ValueContainer.Location = new Point(Size.Width/2-ValueContainer.Width/2-7, 28);
        ValueContainer.AcceptsTab = false;
        ValueContainer.Multiline = false;
        ValueContainer.AppendText(DefaultValue);

        DeleteButton = new ButtonCreator("Supprimer");
        DeleteButton.Size = new Size(90, 20);
        DeleteButton.Location = new Point(Size.Width/2/2-DeleteButton.Width/2-7, 62);
        DeleteButton.Click += new EventHandler(DeleteClick);

        SaveButton = new ButtonCreator("Sauvegarder");
        SaveButton.Size = new Size(90, 20);
        SaveButton.Location = new Point(Size.Width/4*3-SaveButton.Width/2-7, 62);
        SaveButton.Click += new EventHandler(SaveClick);

        Controls.Add(KeyContainer);
        Controls.Add(ValueContainer);
        Controls.Add(DeleteButton);
        Controls.Add(SaveButton);
    }

    private void DeleteClick(object? sender, EventArgs e) => new ConfirmDeleteForm($"{Text.Replace(":", "|.|")}:{DefaultValue.Replace(":", "|.|")}", this).Show();

    private void SaveClick(object? sender, EventArgs e){
        Main.MainForm.Instance.ChangeValue($"{Text.Replace(":", "|.|")}:{DefaultValue.Replace(":", "|.|")}", $"{KeyContainer.Text.Replace(":", "|.|")}:{ValueContainer.Text.Replace(":", "|.|")}");
        Text = KeyContainer.Text;
        DefaultValue = ValueContainer.Text;
    }
}