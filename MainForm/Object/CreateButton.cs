namespace MainObject;

using FormContent;
using Main;

public class CreateButton {
    public static ButtonCreator Button = new ButtonCreator();
    public CreateButton(){
        Button = new ButtonCreator("Ajouter un élément");
        Button.FlatStyle = FlatStyle.System;
        Button.SetBackgroundColor(Color.LightGray);
        Button.Size = new Size(210, 12);
        Button.Location = new Point(-5, 338);
        Button.MouseClick += new MouseEventHandler(ButtonClick);
    }

    private void ButtonClick(object? sender, MouseEventArgs e){
        Point Point = new Point(MainForm.Instance.Location.X + MainForm.Instance.Size.Width, MainForm.Instance.Location.Y);
        new Create.CreateForm(Point).Show();
    }
}