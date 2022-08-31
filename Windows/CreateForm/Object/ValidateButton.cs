namespace CreateObject;

using FormContent;
using Create;

public class ValidateButton {
    public static ButtonCreator Button = new ButtonCreator();

    public ValidateButton(){
        Button = new ButtonCreator("Ajouter");
        Button.FlatStyle = FlatStyle.System;
        Button.SetBackgroundColor(Color.LightGray);
        Button.Size = new Size(150, 20);
        Button.Location = new Point(18, 125);
        Button.MouseClick += new MouseEventHandler(ButtonClick);
    }

    private void ButtonClick(object? sender, MouseEventArgs e){
        CreateForm Cf = CreateForm.Instance;
        string Key = Cf.NameTextBox.Text;
        string Value = Cf.ValueTextBox.Text;

        if(Cf.NameTextBox.ForeColor == Color.Gray || Cf.ValueTextBox.ForeColor == Color.Gray){
            MessageBox.Show("Merci de mettre un Nom et une Valeur à l'élément", "Valeurs Manquantes");
            return;
        }

        Main.MainForm.Instance.AddInList($"{Key.Replace(":", "|.|")}:{Value.Replace(":", "|.|")}");
        Main.MainForm.Instance.SeeFromString(MainObject.Bar.TextBox.ForeColor == Color.Gray ? "" : MainObject.Bar.TextBox.Text);

        MessageBox.Show($"L'élément '{Key}' a été ajouté avec la valeur '{Value}'", "Ajouté avec Succès");
    }
}