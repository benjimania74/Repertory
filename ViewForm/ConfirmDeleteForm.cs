namespace ViewF;

using FormContent;

public class ConfirmDeleteForm : Form {
    private string ToDelete;
    private ViewForm VF;
    private LabelCreator Explain;
    private ButtonCreator Confirm;
    private ButtonCreator Cancel;

    public ConfirmDeleteForm(string ToDelete, ViewForm VF){
        this.ToDelete = ToDelete;
        this.VF = VF;

        Text = "Supprimer " + ToDelete.Split(":")[0].Replace("|.|", ":");
        Size = new Size(300, 100);
        StartPosition = FormStartPosition.CenterScreen;
        Icon = new Icon(@"./icon.ico");

        Explain = new LabelCreator("Supprimer " + ToDelete.Split(":")[0].Replace("|.|", ":") + " ?");

        Confirm = new ButtonCreator("Oui");
        Confirm.Size = new Size(80, 20);
        Confirm.Click += new EventHandler(ConfirmClick);

        Cancel = new ButtonCreator("Non");
        Cancel.Size = new Size(80, 20);
        Cancel.Click += new EventHandler(CancelClick);

        Controls.Add(Explain);
        Controls.Add(Confirm);
        Controls.Add(Cancel);

        Place();
    }

    private void ConfirmClick(object? sender, EventArgs e){
        Main.MainForm.Instance.RemoveFromList(ToDelete);
        MessageBox.Show(ToDelete.Split(":")[0] + " a été supprimé", ToDelete.Split(":")[0] + " supprimé");
        Close();
        VF.Close();
    }

    private void CancelClick(object? sender, EventArgs e) => Close();

    private void Place(){
        Explain.Location = new Point(Size.Width/2-Explain.Width/2-7, 8);
        Confirm.Location = new Point(Size.Width/4-Confirm.Size.Width/2-7, 30);
        Cancel.Location = new Point(Size.Width/4*3-Cancel.Size.Width/2-7, 30);
    }
}