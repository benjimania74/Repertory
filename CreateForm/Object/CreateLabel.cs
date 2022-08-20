namespace CreateObject;

using FormContent;

public class ElementNameLabel {
    public static LabelCreator Label = new LabelCreator();

    public ElementNameLabel(){
        Label = new LabelCreator("Nom de l'élément");
        Label.Size = new Size(Label.Size.Width, 20);
        Label.Location = new Point(100-Label.Size.Width/2-7, 8);
    }
}

public class ElementValueLabel {
    public static LabelCreator Label = new LabelCreator();

    public ElementValueLabel(){
        Label = new LabelCreator("Valeur de l'élément");
        Label.Size = new Size(Label.Size.Width, 20);
        Label.Location = new Point(200/2-Label.Size.Width/2-7, 65);
    }
}