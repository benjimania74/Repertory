namespace Create;

using Main;
using FormContent;
using CreateObject;

public class CreateForm : Form {
    public static CreateForm Instance;
    private LabelCreator NameLabel;
    public TextBox NameTextBox;
    private LabelCreator ValueLabel;
    public TextBox ValueTextBox;
    private ButtonCreator ValidateButton;

    public CreateForm(Point Position){
        Instance = this;
        SuspendLayout();
        ResumeLayout(false);

        Initializer();

        NameLabel = ElementNameLabel.Label;
        NameTextBox = ElementNameTextBox.TextBox;
        ValueLabel = ElementValueLabel.Label;
        ValueTextBox = ElementValueTextBox.TextBox;
        ValidateButton = CreateObject.ValidateButton.Button;

        Controls.Add(NameLabel);
        Controls.Add(NameTextBox);
        Controls.Add(ValueLabel);
        Controls.Add(ValueTextBox);
        Controls.Add(ValidateButton);

        PerformLayout();
    }

    private void Initializer(){
        Text = "Ajouter un élément";
        StartPosition = FormStartPosition.Manual;
        MainForm mainForm = MainForm.Instance;
        Location = new Point(mainForm.Location.X + mainForm.Size.Width + 5, mainForm.Location.Y);
        Size = new Size(200, 200);
        Icon = new Icon(@"./icon.ico");

        new ElementNameLabel();
        new ElementValueLabel();
        new ElementNameTextBox();
        new ElementValueTextBox();
        new CreateObject.ValidateButton();
    }
}